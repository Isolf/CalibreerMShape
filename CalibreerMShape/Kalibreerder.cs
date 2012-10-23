
using System.Diagnostics;
using ESRI.ArcGIS.DataSourcesFile;
using System;
using System.Globalization; 
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF.Connection.Local;
using NLog;

namespace KalibreerMShape
{
    public class Kalibreerder
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ArcObjectsHelper _ArcObjectsHelper;
        private double distanceAlongCurve = 0;
        private bool bRightSide = false;
        private ITable logtable = null;

        public event EventHandler ProgressUpdated;

        public Kalibreerder()
        {
            // 
            try
            {
                _ArcObjectsHelper = new ArcObjectsHelper();

                // Zet de default waarden
                this.FillColor = System.Drawing.Color.Red;
                this.OutlineColor = System.Drawing.Color.Black;

                this.KleurVormpuntMetAfwijking = System.Drawing.Color.Red;
                this.KleurVormpuntBuitenZoekAfstand = System.Drawing.Color.Orange;
                this.KleurLijnBuitenZoekAfstand = System.Drawing.Color.Yellow;
                this.KleurVormpuntBuitenInterval = System.Drawing.Color.BlueViolet;
                this.KleurLijnNietMonotoon = System.Drawing.Color.Red;
                this.KleurVormpuntBijgewerkt = System.Drawing.Color.Green;
                this.KleurVormpuntNietBijgewerkt = System.Drawing.Color.Red;
                this.KleurRaaiMetOngeldigeHmwaarde = System.Drawing.Color.Red;

                this.TolerantieVormpuntBuitenInterval = 10;
                this.lrs_selectie = "";

                this.raai_selectie = "";

                this.KalibreerVormpuntenMetSpoorhartlijn = false;
                this.KalibreerVormpuntenMetRaaien = true;
                this.MarkeerLijnNietMonotoon = true;
                this.OpslaanLijnNietMonotoon = false;
                this.SaveEdits = true;
                this.LogVormpunten = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }

        }

        private int _progress;
        public int progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                if (this.ProgressUpdated != null)
                {
                    this.ProgressUpdated(this, null);
                }
            }
        }

        public string mshape_sleutel1 { get; set; }
        public string mshape_sleutel2 { get; set; }
        public double mshape_maxafstand { get; set; }
        public double mshape_tolerantie { get; set; }
        public double raai_afstand { get; set; }
        public ESRI.ArcGIS.Carto.IFeatureLayer flMShape { get; set; }
        public IFeatureClass fcLRS { get; set; }
        public IFeatureClass fcRaai { get; set; }
        public System.Drawing.Color FillColor { get; set; }
        public System.Drawing.Color OutlineColor { get; set; }

        public bool MarkeerLijnBuitenZoekAfstand { get; set; }
        public System.Drawing.Color KleurLijnBuitenZoekAfstand { get; set; }
        public double AfstandLijnBuitenZoekAfstand { get; set; }

        public bool MarkeerVormpuntBuitenZoekAfstand { get; set; }
        public System.Drawing.Color KleurVormpuntBuitenZoekAfstand { get; set; }
        public double AfstandVormpuntBuitenZoekAfstand { get; set; }

        public bool MarkeerVormpuntMetAfwijking { get; set; }
        public System.Drawing.Color KleurVormpuntMetAfwijking { get; set; }
        public double VerschilVormpuntMetAfwijking { get; set; }

        public System.Drawing.Color KleurVormpuntBuitenInterval { get; set; }
        public bool MarkeerVormpuntBuitenInterval { get; set; }
        public double TolerantieVormpuntBuitenInterval { get; set; }

        public System.Drawing.Color KleurVormpuntNietBijgewerkt { get; set; }
        public bool MarkeerVormpuntNietBijgewerkt { get; set; }

        public System.Drawing.Color KleurVormpuntBijgewerkt { get; set; }
        public bool MarkeerVormpuntBijgewerkt { get; set; }

        public System.Drawing.Color KleurRaaiMetOngeldigeHmwaarde { get; set; }
        public bool MarkeerRaaiMetOngeldigeHmwaarde { get; set; }

        public bool MarkeerLijnNietMonotoon { get; set; }
        public System.Drawing.Color KleurLijnNietMonotoon { get; set; }
        public bool OpslaanLijnNietMonotoon { get; set; }

        public bool KalibreerVormpuntenMetSpoorhartlijn { get; set; }
        public bool KalibreerVormpuntenMetRaaien { get; set; }

        public bool SaveEdits { get; set; }
        public bool LogVormpunten { get; set; }

        /// <summary>
        /// Zoekt het dichtstbijzijnde punt op de spoorhartlijnen die binnen de zoekafstand liggen en waarvoor geldt dat de gevonden waarde binnen
        /// het kilometerinterval km_begin en km_eind ligt. De resultaten worden via de parameters outPoint, outPointGevonden en pDistance
        /// </summary>
        /// <param name="Point"></param>
        /// <param name="IndexQueryLRS"></param>
        /// <param name="km_begin"></param>
        /// <param name="km_eind"></param>
        /// <param name="outPoint"></param>
        /// <param name="outPointGevonden"></param>
        /// <param name="pDistance"></param>
        private void ZoekPuntOpSpoorhartlijn(IPoint Point, IIndexQuery2 IndexQueryLRS, double km_begin, double km_eind, out IPoint outPoint, out bool outPointGevonden, out double outPointDistance)
        {
            try
            {
                IPolygon buffer = (Point as ITopologicalOperator).Buffer(this.mshape_maxafstand) as IPolygon;

                distanceAlongCurve = 0;
                bRightSide = false;

                object pSAIds = null;
                double pDistanceToNearestFeature = 0;
                IndexQueryLRS.NearestFeatures(buffer as IGeometry, out pSAIds, out pDistanceToNearestFeature);

                if ((pSAIds == null) || (pDistanceToNearestFeature > 0.001)) // 1 mm
                {
                    outPoint = null;
                    outPointGevonden = false;
                    outPointDistance = double.PositiveInfinity;
                }
                else // er zijn features gevonden binnen de zoekafstand
                {
                    IFeatureCursor FeatureCursorIntersectsLRS = fcLRS.GetFeatures(pSAIds, false);

                    try
                    {
                        outPoint = null;
                        outPointGevonden = false;
                        outPointDistance = double.PositiveInfinity;

                        IFeature featureLRS = FeatureCursorIntersectsLRS.NextFeature();

                        // Zoek het punt dat binnen de kilometertolerantie valt
                        double km_begin_mshape_tolerantie = km_begin - (this.mshape_tolerantie / 1000);
                        double km_eind_mshape_tolerantie = km_eind + (this.mshape_tolerantie / 1000);
                        while (featureLRS != null)
                        {

                            ICurve curveLRS = featureLRS.Shape as ICurve;
                            outPoint = new ESRI.ArcGIS.Geometry.Point();
                            curveLRS.QueryPointAndDistance(esriSegmentExtension.esriNoExtension, Point as IPoint, false, outPoint, distanceAlongCurve, ref outPointDistance, bRightSide);
                            if (outPoint.M >= km_begin_mshape_tolerantie && outPoint.M < km_eind_mshape_tolerantie)
                            {
                                // punt gevonden, verlaat de loop.
                                outPointGevonden = true;
                                break;
                            }

                            featureLRS = FeatureCursorIntersectsLRS.NextFeature();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(FeatureCursorIntersectsLRS);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                throw;
            }

        }

        private void ZoekPuntOpSpoorhartlijn(IPoint Point, IList<IPolyline> PolylinesLRS, double km_begin, double km_eind, out IPoint outPoint, out bool outPointGevonden, out double outPointDistance)
        {
            try
            {
                distanceAlongCurve = 0;
                bRightSide = false;

                if (PolylinesLRS.Count == 0)
                {
                    outPoint = null;
                    outPointGevonden = false;
                    outPointDistance = double.PositiveInfinity;
                }
                else // er zijn features gevonden binnen de zoekafstand
                {
                    outPoint = null;
                    outPointGevonden = false;
                    outPointDistance = double.PositiveInfinity;

                    // Zoek het punt dat binnen de kilometertolerantie valt
                    double km_begin_mshape_tolerantie = km_begin - (this.mshape_tolerantie / 1000);
                    double km_eind_mshape_tolerantie = km_eind + (this.mshape_tolerantie / 1000);
                    foreach (IPolyline Polyline in PolylinesLRS)
                    {

                        ICurve curveLRS = Polyline as ICurve;
                        outPoint = new ESRI.ArcGIS.Geometry.Point();
                        curveLRS.QueryPointAndDistance(esriSegmentExtension.esriNoExtension, Point as IPoint, false, outPoint, distanceAlongCurve, ref outPointDistance, bRightSide);
                        if (outPoint.M >= km_begin_mshape_tolerantie && outPoint.M < km_eind_mshape_tolerantie)
                        {
                            // punt gevonden, verlaat de loop.
                            outPointGevonden = true;
                            break;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }

        }

        public void LoadSettings()
        {
            IFeatureWorkspace FeatureWorkspaceSDE = null;
            IFeatureWorkspace FeatureWorkspaceMShape = null;
            // Open de workspace
            try
            {
                //FeatureWorkspaceSDE = (_ArcObjectsHelper.SDEWorkspaceFromPropertySet("gisserver", "5151", "VIEWER", "VIEWER", "", "SDE.DEFAULT") as IFeatureWorkspace);
                FeatureWorkspaceMShape = (flMShape.FeatureClass as IDataset).Workspace as IFeatureWorkspace;

                try
                {
                    string name = Properties.Settings.Default.lrs;
                    if (name.Contains("."))
                    {
                        name = new List<string>(name.Split('.'))[1];
                    }

                    bool NameExists = (FeatureWorkspaceMShape as IWorkspace2).get_NameExists(esriDatasetType.esriDTFeatureClass, name);
                    if (NameExists)
                    {
                        this.fcLRS = FeatureWorkspaceMShape.OpenFeatureClass(name);
                    }
                    else
                    {
                        this.fcLRS = FeatureWorkspaceSDE.OpenFeatureClass(Properties.Settings.Default.lrs);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                    logger.LogException(LogLevel.Trace, "FOUT", ex);
                    throw new System.Exception(string.Format("De LRS featureclass '{0}' is niet gevonden in de GIS database of in de workspace van de m-shape",
                                                             Properties.Settings.Default.lrs));
                }


                try
                {
                    string name = Properties.Settings.Default.raai;
                    if (name.Contains("."))
                    {
                        name = new List<string>(name.Split('.'))[1];
                    }

                    bool NameExists = (FeatureWorkspaceMShape as IWorkspace2).get_NameExists(esriDatasetType.esriDTFeatureClass, name);
                    if (NameExists)
                    {
                        this.fcRaai  = FeatureWorkspaceMShape.OpenFeatureClass(name);
                    }
                    else
                    {
                        this.fcRaai = FeatureWorkspaceSDE.OpenFeatureClass(Properties.Settings.Default.raai);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                    logger.LogException(LogLevel.Trace, "FOUT", ex);
                    throw new System.Exception(string.Format("De raai featureclass '{0}' is niet gevonden in de GIS database of in de workspace van de m-shape",
                                                             Properties.Settings.Default.lrs));
                }

                this.raai_afstand = Properties.Settings.Default.raai_afstand;
                this.raai_selectie = Properties.Settings.Default.raai_selectie;
                this.mshape_sleutel1 = Properties.Settings.Default.mshape_sleutel1;
                this.mshape_sleutel2 = Properties.Settings.Default.mshape_sleutel2;
                this.mshape_maxafstand = Properties.Settings.Default.mshape_maxafstand;
                this.mshape_tolerantie = Properties.Settings.Default.mshape_tolerantie;
                this.AfstandLijnBuitenZoekAfstand = mshape_maxafstand;
                this.AfstandVormpuntBuitenZoekAfstand = mshape_maxafstand;
                this.VerschilVormpuntMetAfwijking = 500;
                this.lrs_selectie = Properties.Settings.Default.lrs_selectie;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }

        }

        internal void Show()
        {
            FormKalibreren Form = new FormKalibreren(this);
            Form.ShowDialog();
        }


        public string lrs_selectie { get; set; }
        public string raai_selectie { get; set; }

        public string fcLRS_name
        {
            get
            {
                return (fcLRS as IDataset).Workspace.PathName + "\\" + (fcLRS as IDataset).BrowseName;
            }
        }


        public void Uitvoeren()
        {

            try
            {
                // Maak de logtabel
                if (this.LogVormpunten)
                {
                    logtable = this._ArcObjectsHelper.CreateOrOpenTableLog(((flMShape as IDataset).Workspace as IWorkspace2), "logtable", null);
                }

                IFeatureWorkspace fw = (flMShape as IDataset).Workspace as IFeatureWorkspace;
                IWorkspaceEdit WorkspaceEdit = fw as IWorkspaceEdit;
                IFeatureSelection FeatureSelectionMShape = flMShape as IFeatureSelection;

                WorkspaceEdit.StartEditing(false);
                try
                {
                    #region Logtabel legen
                    WorkspaceEdit.StartEditOperation();
                    try
                    {
                        if (this.LogVormpunten)
                        { logtable.DeleteSearchedRows(null); }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        WorkspaceEdit.StopEditOperation();
                    }
                    #endregion

                    #region Snijpunten invoegen
                    if (this.KalibreerVormpuntenMetRaaien)
                    {
                        WorkspaceEdit.StartEditOperation();
                        try
                        {
                            this.KalibreerVormpuntenOpBasisVanRaaien(FeatureSelectionMShape);
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            WorkspaceEdit.StopEditOperation();
                        }
                    }
                    #endregion

                    #region Kalibreren
                    if (this.KalibreerVormpuntenMetSpoorhartlijn)
                    {
                        WorkspaceEdit.StartEditOperation();
                        try
                        {
                            this.KalibreerVormpuntenOpBasisVanSpoorhartlijn(FeatureSelectionMShape);
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            WorkspaceEdit.StopEditOperation();
                        }
                    }
                    #endregion

                }
                catch (System.Exception ex)
                {
                    this.SaveEdits = false;
                    System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                    logger.LogException(LogLevel.Trace, "FOUT", ex);
                    throw;
                }
                finally
                {
                    WorkspaceEdit.StopEditing(this.SaveEdits);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }

        }

        private void KalibreerVormpuntenOpBasisVanSpoorhartlijn(IFeatureSelection FeatureSelectionMShape)
        {
            #region Bepaal de overlappende extent van raaien en selectie
            IGeoDataset GeoDatasetMShape = flMShape as IGeoDataset;
            IGeoDataset GeodatasetLRS = fcLRS as IGeoDataset;

            IEnvelope pQueryingGeometryFullExtent = GeoDatasetMShape.Extent;
            pQueryingGeometryFullExtent.Union(GeodatasetLRS.Extent);
            pQueryingGeometryFullExtent.Expand(10000, 10000, false);
            #endregion Bepaal de overlappende extent van raaien en selectie

            int featurecount = FeatureSelectionMShape.SelectionSet.Count;
            int featurecounter = 0;

            ICursor SelectionCursor = null;

            if (featurecount == 0)
            {
                SelectionCursor = ((FeatureSelectionMShape as IFeatureLayer).FeatureClass.Search(null, false)) as ICursor;
                featurecount = (FeatureSelectionMShape as IFeatureLayer).FeatureClass.FeatureCount(null);
            }
            else
            {
                FeatureSelectionMShape.SelectionSet.Search(null, false, out SelectionCursor);
            }

            IPolyline Polyline = null;
            IPolygon buffer = null;
            IPointCollection PointCollection = null;

            IList<IPolyline> PolylinesLRS = null;

            try
            {

                IFeature feature = SelectionCursor.NextRow() as IFeature;
                while (feature != null)
                {

                    Polyline = feature.ShapeCopy as IPolyline;
                    PointCollection = Polyline as IPointCollection;

                    #region lees de begin- en eindkilometrering en het selectie criterium
                    double m_begin = (Polyline as IPointCollection).get_Point(0).M;
                    double m_eind = (Polyline as IPointCollection).get_Point((Polyline as IPointCollection).PointCount - 1).M;
                    string sleutel1 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel1)));
                    string sleutel2 = null;
                    if (this.mshape_sleutel2 != "")
                    {
                        sleutel2 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel2)));
                    }

                    #endregion

                    // Selecteer alle LRS lijnen binnen de zoekafstand
                    ISpatialFilter SpatialFilter = new SpatialFilter();
                    IQueryFilter QueryFilter = SpatialFilter;

                    buffer = (Polyline as ITopologicalOperator).Buffer(Properties.Settings.Default.mshape_maxafstand) as IPolygon;

                    SpatialFilter.Geometry = buffer;
                    SpatialFilter.GeometryField = fcLRS.ShapeFieldName;
                    string whereclauseLRS = Properties.Settings.Default.lrs_selectie;
                    SpatialFilter.WhereClause = string.Format(whereclauseLRS, sleutel1, sleutel2);
                    SpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;

                    ESRI.ArcGIS.Geodatabase.IFeatureCursor featureCursor = fcLRS.Search(QueryFilter, false);

                    try
                    {
                        PolylinesLRS = new List<IPolyline>();
                        IFeature featureLRS = featureCursor.NextFeature();
                        while (featureLRS != null)
                        {
                            PolylinesLRS.Add(featureLRS.ShapeCopy as IPolyline);
                            featureLRS = featureCursor.NextFeature();
                        }

                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(featureCursor);
                    }

                    // Controleer of er een spoorhartlijn (LRS) in de buurt ligt. Zo niet, dan evt. markeren
                    if ((PolylinesLRS.Count == 0) && (this.MarkeerLijnBuitenZoekAfstand))
                    {
                        _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Polyline, this.KleurLijnBuitenZoekAfstand, this.KleurLijnBuitenZoekAfstand);
                        // Als er geen spoorhartlijn (LRS) in de buurt ligt, dan hoeven ook niet alle vormpunten doorlopen te worden.
                        continue; // while (feature != null)
                    }

                    #region Doorloop alle vormpunten en werk de vormpunten bij
                    bool bUpdated = false;
                    bool bNietMonotoon = false;
                    bool outPointGevonden = false;
                    double pDistance = 0;

                    for (int i = 1; i < PointCollection.PointCount-1; i++) // sla het eerste en het laatste punt over
                    {
                        // zoek de dichtstbijzijnde feature, eventueel aangevuld met geocode in een queryfilter
                        IPoint Point = PointCollection.get_Point(i);
                        IPoint outPoint = new ESRI.ArcGIS.Geometry.Point();
                        outPointGevonden = false;
                        pDistance = double.PositiveInfinity;
                        bUpdated = false;

                        this.ZoekPuntOpSpoorhartlijn(Point, PolylinesLRS, m_begin, m_eind, out outPoint, out outPointGevonden, out pDistance);
                        if (this.LogVormpunten)
                        {
                            if (outPointGevonden)
                            { this._ArcObjectsHelper.LogRecord(logtable, feature.OID, i, Point.X, Point.Y, Point.M, outPoint.X, outPoint.Y, outPoint.M); }
                            else
                            { this._ArcObjectsHelper.LogRecord(logtable, feature.OID, i, Point.X, Point.Y, Point.M, Point.X, Point.Y, Point.M); }
                        }

                        // Als er een punt gevonden is, binnen de zoekafstand en binnen het kilometerinterval
                        if (outPointGevonden)
                        {
                            if (Math.Abs((Point as IPoint).M - outPoint.M) > (this.VerschilVormpuntMetAfwijking / 1000))
                            {
                                if (MarkeerVormpuntMetAfwijking)
                                { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntMetAfwijking, this.KleurVormpuntMetAfwijking); }
                            }

                            if ((pDistance > this.AfstandVormpuntBuitenZoekAfstand) && (this.MarkeerVormpuntBuitenZoekAfstand))
                            { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBuitenZoekAfstand, this.KleurVormpuntBuitenZoekAfstand); }

                            Point.M = outPoint.M;

                            PointCollection.UpdatePoint(i, Point);
                            bUpdated = true;
                        }
                        else if ((!outPointGevonden) && (outPoint != null)) // er is wel een punt gevonden, maar niet binnen het kilometerinterval.
                        {
                            // Als er een punt buiten het kilometerinterval gevonden is, binnen de zoekafstand, markeer het punt dan 
                            if ((this.MarkeerVormpuntMetAfwijking) && (Math.Abs((Point as IPoint).M - outPoint.M) > (this.VerschilVormpuntMetAfwijking / 1000)))
                            { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntMetAfwijking, this.KleurVormpuntMetAfwijking); }

                            if ((this.MarkeerVormpuntBuitenInterval) && !(between(m_begin, m_eind, outPoint.M, (TolerantieVormpuntBuitenInterval / 1000)))) 
                            { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBuitenInterval, this.KleurVormpuntBuitenInterval); }

                            if ((pDistance > this.AfstandVormpuntBuitenZoekAfstand) && (this.MarkeerVormpuntBuitenZoekAfstand))
                            { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBuitenZoekAfstand, this.KleurVormpuntBuitenZoekAfstand); }

                        }
                        else if (!outPointGevonden) // er is geen punt gevonden binnen de zoekafstand
                        {
                            if (this.MarkeerVormpuntBuitenZoekAfstand)
                            { _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBuitenZoekAfstand, this.KleurVormpuntBuitenZoekAfstand); }
                        }

                        #region Markeer de bijgewerkte en niet bijgewerkte punten
                        if ((bUpdated) && (this.MarkeerVormpuntBijgewerkt))
                        {
                            _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBijgewerkt, this.KleurVormpuntBijgewerkt);
                        }
                        if (!(bUpdated) && (this.MarkeerVormpuntNietBijgewerkt))
                        {
                            _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntNietBijgewerkt, this.KleurVormpuntNietBijgewerkt);
                        }
                        #endregion

                    }
                    #endregion // doorloop de vormpunten

                    #region Reset begin- en eindkilometer
                    this.ResetBeginEnEindMeasure(Polyline, m_begin, m_eind, false);
                    #endregion

                    #region Controleer of de lijn monotoon oplopend of aflopend is en markeer de lijn.
                    int MMonotonicity = ((PointCollection as IMSegmentation3).MMonotonicity);
                    if (MMonotonicity == 5 || MMonotonicity == 7 || MMonotonicity == 15)
                    {
                        bNietMonotoon = true;
                        if (this.MarkeerLijnNietMonotoon)
                        {
                            _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, PointCollection as IPolyline, this.KleurLijnNietMonotoon, this.KleurLijnNietMonotoon);
                        }
                    }

                    if ((bNietMonotoon) && (this.OpslaanLijnNietMonotoon))
                    {
                        feature.Shape = (PointCollection as IGeometry);
                        // UpdateCursor.UpdateFeature(feature);
                    }
                    else if (!bNietMonotoon)
                    {
                        feature.Shape = (PointCollection as IGeometry);
                    }
                    #endregion

                    // Voortgang
                    featurecounter += 1;
                    this.progress = (100 * featurecounter) / featurecount;

                    // Bijwerken
                    feature.Store();

                    // Volgende feature
                    feature = SelectionCursor.NextRow() as IFeature;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }
            finally
            {
                ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(SelectionCursor);
            }

        }


        private void KalibreerVormpuntenOpBasisVanRaaien(IFeatureSelection FeatureSelectionMShape)
        {

            IPolygon buffer;
            int featurecount = FeatureSelectionMShape.SelectionSet.Count;
            int featurecounter = 0;
            double m_begin = 0;
            double m_eind = 0;

            ICursor SelectionCursor = null;

            if (featurecount == 0)
            {
                SelectionCursor = ((FeatureSelectionMShape as IFeatureLayer).FeatureClass.Search(null, false)) as ICursor;
                featurecount = (FeatureSelectionMShape as IFeatureLayer).FeatureClass.FeatureCount(null);
            }
            else
            {
                FeatureSelectionMShape.SelectionSet.Search(null, false, out SelectionCursor);
            }

            try
            {
                IFeature feature = SelectionCursor.NextRow() as IFeature;

                string sleutel1 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel1)));
                string sleutel2 = null;
                if (this.mshape_sleutel2 != "")
                {
                    sleutel2 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel2)));
                }

                IPolyline Polyline = null;
                IPolyline RaaiExtended = null;
                string hmwaarde = "";
                double hmgetal = 0;

                while (feature != null)
                {
                    // Vraag de lijn op
                    Polyline = feature.ShapeCopy as IPolyline;
                    m_begin = (Polyline as IPointCollection).get_Point(0).M;
                    m_eind = (Polyline as IPointCollection).get_Point((Polyline as IPointCollection).PointCount-1).M;

                    // bestaande measures wissen
                    (Polyline as IMAware).DropMs();

                    buffer = (Polyline as ITopologicalOperator).Buffer(Properties.Settings.Default.raai_afstand) as IPolygon;

                    // Selecteer alle LRS lijnen binnen de zoekafstand
                    ISpatialFilter SpatialFilter = new SpatialFilter();
                    IQueryFilter QueryFilter = SpatialFilter;
                    IFeature FeatureRaai = null;

                    SpatialFilter.Geometry = buffer;
                    SpatialFilter.GeometryField = fcRaai.ShapeFieldName;
                    string whereclause = Properties.Settings.Default.raai_selectie;
                    SpatialFilter.WhereClause = string.Format(whereclause, sleutel1, sleutel2);
                    SpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                    ESRI.ArcGIS.Geodatabase.IFeatureCursor FeatureCursorRaaien = fcRaai.Search(QueryFilter, false);

                    try
                    {
                        FeatureRaai = FeatureCursorRaaien.NextFeature();

                        // this._ArcObjectsHelper.AddGraphicToMap((ArcMap.Document as IMxDocument).FocusMap, Polyline, System.Drawing.Color.Red, System.Drawing.Color.Red);
                        while (FeatureRaai != null)
                        {
                            RaaiExtended = FeatureRaai.ShapeCopy as IPolyline;
                            hmwaarde = Convert.ToString(FeatureRaai.get_Value(FeatureRaai.Fields.FindField(Properties.Settings.Default.raai_hmgetal)));
                            if (!(double.TryParse(hmwaarde, NumberStyles.Float, CultureInfo.InvariantCulture, out hmgetal))) 
                            {
                                if (this.MarkeerRaaiMetOngeldigeHmwaarde)
                                { _ArcObjectsHelper.AddGraphicToMap(FeatureRaai.ShapeCopy, this.KleurRaaiMetOngeldigeHmwaarde); }
                                continue; 
                            }

                            if (between(m_begin, m_eind, hmgetal))
                            {
                                _ArcObjectsHelper.ScaleRaai(ref RaaiExtended);
                                _ArcObjectsHelper.InsertPointAtIntersection(ref Polyline, RaaiExtended as IGeometry, hmgetal);
                            }

                            FeatureRaai = FeatureCursorRaaien.NextFeature();

                        }

                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                        logger.LogException(LogLevel.Trace, "FOUT", ex);
                        throw;
                    }
                    finally
                    {
                        FeatureRaai = null;
                        QueryFilter = null;
                        ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(FeatureCursorRaaien);
                    }

                    // bijwerken measures met oorspronkelijke begin- en eindmeasure
                    this.ResetBeginEnEindMeasure(Polyline, m_begin, m_eind, true);

                    // controleer of de lijn monotoon op- of aflopend is
                    bool bNietMonotoon = false;
                    #region Controleer of de lijn monotoon oplopend of aflopend is en markeer de lijn.
                    int MMonotonicity = ((Polyline as IMSegmentation3).MMonotonicity);
                    if (MMonotonicity == 5 || MMonotonicity == 7 || MMonotonicity == 15)
                    {
                        bNietMonotoon = true;
                        if (this.MarkeerLijnNietMonotoon)
                        {
                            _ArcObjectsHelper.AddGraphicToMap(Polyline, this.KleurLijnNietMonotoon);
                        }
                    }

                    if ((bNietMonotoon) && (this.OpslaanLijnNietMonotoon))
                    {
                        feature.Shape = Polyline;
                        feature.Store();
                    }
                    else if (!bNietMonotoon)
                    {
                        feature.Shape = Polyline;
                        feature.Store();
                    }
                    #endregion

                    // voortgang
                    featurecounter += 1;
                    this.progress = (100 * featurecounter) / featurecount;

                    feature = SelectionCursor.NextRow() as IFeature;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }
            finally
            {
                ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(SelectionCursor);
            }

        }

        private void ResetBeginEnEindMeasure(IPolyline Polyline, double m_begin, double m_eind, bool CalculateNonSimpleMs)
        {
            try
            {
                IPoint Point = null;
                Point = (Polyline as IPointCollection).get_Point(0);
                Point.M = m_begin;
                (Polyline as IPointCollection).UpdatePoint(0, Point);

                int PointCount = (Polyline as IPointCollection).PointCount;
                Point = (Polyline as IPointCollection).get_Point((Polyline as IPointCollection).PointCount - 1);
                Point.M = m_eind;
                (Polyline as IPointCollection).UpdatePoint((Polyline as IPointCollection).PointCount - 1, Point);

                if (CalculateNonSimpleMs)
                {
                    (Polyline as IMSegmentation3).CalculateNonSimpleMs();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Er is een onverwachte fout opgetreden; raadpleeg de logfile: " + ex.Message + ": " + ex.StackTrace, "Foutmelding");
                logger.LogException(LogLevel.Trace, "FOUT", ex);
                throw;
            }

        }

        private bool between(double from, double to, double m, double tolerantie)
        {
            if (from > to) { from += tolerantie; to -= tolerantie; }
            else { from -= tolerantie; to += tolerantie; }
            
            return between(from, to, m);

        }

        private bool between(double from, double to, double m)
        {
            if (from > to) { return (to <= m && m <= from); }
            else { return (from <= m && m <= to); }
        }

    }
}
