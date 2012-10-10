using System.Diagnostics;
using ESRI.ArcGIS.DataSourcesFile;
using System;
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

namespace KalibreerMShape
{
    public class Kalibreerder
    {
        private ArcObjectsHelper _ArcObjectsHelper;

        public event EventHandler ProgressUpdated;

        public Kalibreerder()
        {
            // 
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

            this.TolerantieVormpuntBuitenInterval = 10;
            this.lrs_selectie = "";

            this.MarkeerLijnNietMonotoon = true;
            this.OpslaanLijnNietMonotoon = false;
            this.SaveEdits = true;

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

        public string mshape_beginkm { get; set; }
        public string mshape_eindkm { get; set; }
        public string mshape_sleutel1 { get; set; }
        public string mshape_sleutel2 { get; set; }
        public double mshape_maxafstand  { get; set; }
        public double mshape_tolerantie { get; set; }
        public string lrs_sleutel { get; set; }
        public string raai_sleutel { get; set; }
        public double raai_afstand { get; set; }
        public IFeatureClass fcMShape { get; set; }
        public IFeatureClass fcLRS { get; set; }
        public IFeatureClass fcRaai { get; set; }
        public IFeatureWorkspace FeatureWorkspace { get; set; }
        public  System.Drawing.Color FillColor  { get; set; }
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

        public bool MarkeerLijnNietMonotoon { get; set; }
        public System.Drawing.Color KleurLijnNietMonotoon { get; set; }
        public bool OpslaanLijnNietMonotoon { get; set; }

        public bool SaveEdits { get; set; }
 
        public void Kalibreer()
        {

            // Logtabel maken
            ITable logtable = this._ArcObjectsHelper.CreateOrOpenTableLog(((this.fcMShape as IDataset).Workspace as IWorkspace2), "logtable", null);

            // TODO: nog met een aantal kilometer uitbreiden
            IGeoDataset GeoDatasetMShape = fcMShape as IGeoDataset;

            #region FeatureIndexLRS

            IFeatureCursor FeatureCursorLRS = null;
            IFeatureIndex FeatureIndexLRS = new FeatureIndex();
            FeatureIndexLRS.FeatureClass = fcLRS;

            IQueryFilter QueryFilterLRS = new QueryFilter();
            QueryFilterLRS.SubFields = string.Format("{0},{1}", fcLRS.ShapeFieldName, Properties.Settings.Default.lrs_sleutel);

            IGeoDataset GeodatasetLRS = fcLRS as IGeoDataset;
            FeatureIndexLRS.Index(null, GeoDatasetMShape.Extent);
            IIndexQuery2 IndexQueryLRS = FeatureIndexLRS as IIndexQuery2;
            #endregion

            #region FeatureIndexRaai
            IFeatureIndex FeatureIndexRaai = new FeatureIndex();
            FeatureIndexRaai.FeatureClass = fcRaai;

            IQueryFilter QueryFilterRaai = new QueryFilter();
            QueryFilterRaai.SubFields = string.Format("{0},{1}", fcRaai.ShapeFieldName, Properties.Settings.Default.raai_sleutel);

            IGeoDataset GeodatasetRaai = fcRaai as IGeoDataset;
            FeatureIndexRaai.Index(null, GeoDatasetMShape.Extent);
            IIndexQuery2 IndexQueryRaai = FeatureIndexRaai as IIndexQuery2;
            #endregion

            IFeatureWorkspace fw = (fcMShape as IDataset).Workspace as IFeatureWorkspace;
            IWorkspaceEdit WorkspaceEdit = fw as IWorkspaceEdit;

            WorkspaceEdit.StartEditing(false);
            WorkspaceEdit.StartEditOperation();
            try
            {

                int featurecount = fcMShape.FeatureCount(null);
                int featurecounter = 0;

                IFeatureCursor UpdateCursor = fcMShape.Update(null, false);
                IFeature feature = UpdateCursor.NextFeature();
                while (feature != null)
                {

                    double km_begin = Convert.ToDouble(feature.get_Value(feature.Fields.FindField(this.mshape_beginkm)));
                    double km_eind = Convert.ToDouble(feature.get_Value(feature.Fields.FindField(this.mshape_eindkm)));
                    string sleutel1 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel1)));
                    string sleutel2 = null;
                    if (this.mshape_sleutel2 != "")
                    {
                        sleutel2 = Convert.ToString(feature.get_Value(feature.Fields.FindField(this.mshape_sleutel2)));
                    }

                    string whereclause = Properties.Settings.Default.lrs_selectie;

                    if (km_begin > km_eind)
                    {
                        km_eind = Convert.ToDouble(feature.get_Value(feature.Fields.FindField(this.mshape_beginkm)));
                        km_begin = Convert.ToDouble(feature.get_Value(feature.Fields.FindField(this.mshape_eindkm)));
                    }

                    QueryFilterLRS.WhereClause = string.Format(whereclause, sleutel1, sleutel2);
                    FeatureCursorLRS = fcLRS.Search(QueryFilterLRS, false);
                    FeatureIndexLRS.FeatureCursor = FeatureCursorLRS;
                    FeatureIndexLRS.Index(null, GeoDatasetMShape.Extent);

                    IPolyline Polyline = feature.ShapeCopy as IPolyline;

                    // Selecteer alle raaien en voeg vormpunten in.
                    IPolygon buffer = (Polyline as ITopologicalOperator).Buffer(Properties.Settings.Default.raai_afstand) as IPolygon;
                    object pSAIds;
                    double pDistance = 0;

                    // TODO: ALS DE FEATURE BUITEN DE INDEX EXTENT VALT LIJKT ER EEN FOUT OP TE TREDEN.
                    IndexQueryRaai.NearestFeatures(buffer as IGeometry, out pSAIds, out pDistance);

                    IFeatureCursor FeatureCursorRaaien = fcRaai.GetFeatures(pSAIds, false);
                    IFeature FeatureRaai = FeatureCursorRaaien.NextFeature();

                    while (FeatureRaai != null)
                    {
                        IPolyline RaaiExtended = FeatureRaai.ShapeCopy as IPolyline;

                        _ArcObjectsHelper.ScalePolyline(RaaiExtended, 10);
                        IGeometry line = _ArcObjectsHelper.ScaleRaai(RaaiExtended);
                        //_ArcObjectsHelper.AddGraphicToMap((ArcMap.Document as IMxDocument).FocusMap , (line as IGeometry), System.Drawing.Color.Red, System.Drawing.Color.Red);

                        // topologicaloperator intersect
                        IGeometry pIntersect = Polyline;
                        _ArcObjectsHelper.InsertPointAtIntersection(ref pIntersect, line as IGeometry);

                        FeatureRaai = FeatureCursorRaaien.NextFeature();

                    }

                    int pClosestFeatureFID = 0;
                    double distance = 0;

                    // Controleer of er LRS features in de buurt liggen. Zo niet, dan evt. markeren
                    IndexQueryLRS.NearestFeature(Polyline, out pClosestFeatureFID, out distance);
                    if ((distance > mshape_maxafstand) && (this.MarkeerLijnBuitenZoekAfstand))
                    {
                        _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Polyline, this.KleurLijnBuitenZoekAfstand, this.KleurLijnBuitenZoekAfstand);
                    }

                    // doorloop alle vormpunten
                    IPointCollection PointCollection = Polyline as IPointCollection;
                    double distanceAlongCurve = 0;
                    double distanceFromCurve = 0;
                    bool bRightSide = false;
                    bool bUpdated = false;
                    bool bNietMonotoon = false;

                    for (int i = 0; i < PointCollection.PointCount; i++)
                    {
                        // zoek de dichtstbijzijnde feature, eventueel aangevuld met geocode in een queryfilter
                        IGeometry Point = PointCollection.get_Point(i);
                        IPoint outPoint = new ESRI.ArcGIS.Geometry.Point();
                        distanceAlongCurve = 0;
                        distanceFromCurve = 0;
                        bRightSide = false;
                        bUpdated = false;
                        bNietMonotoon = false;

                        // TODO: filter op geosubcode zetten op featureindex (velden in settings opnemen)
                        IndexQueryLRS.NearestFeature(Point, out pClosestFeatureFID, out distance);
                        ICurve featureLRS = fcLRS.GetFeature(pClosestFeatureFID).Shape as ICurve;

                        if (distance > mshape_maxafstand) 
                        {
                            if (this.MarkeerVormpuntBuitenZoekAfstand)
                            {
                                _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Polyline, this.KleurLijnBuitenZoekAfstand, this.KleurLijnBuitenZoekAfstand);
                            }
                        }
                        else
                        {
                            featureLRS.QueryPointAndDistance(esriSegmentExtension.esriNoExtension, Point as IPoint, false, outPoint, distanceAlongCurve, distanceFromCurve, bRightSide);

                            //_ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, outPoint, Color, Color);


                            double km_begin_mshape_tolerantie = km_begin - (this.mshape_tolerantie  / 1000);
                            double km_eind_mshape_tolerantie = km_eind + (this.mshape_tolerantie / 1000);
                            if (outPoint.M >= km_begin_mshape_tolerantie && outPoint.M < km_eind_mshape_tolerantie)
                            {
                                if (Math.Abs((Point as IPoint).M - outPoint.M) > (this.VerschilVormpuntMetAfwijking / 1000))
                                {
                                    if (MarkeerVormpuntMetAfwijking)
                                    {
                                        _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntMetAfwijking, this.KleurVormpuntMetAfwijking);
                                    }
                                }

                                _ArcObjectsHelper.LogRecord(logtable,
                                    (Point as IPoint).X,
                                    (Point as IPoint).Y,
                                    (Point as IPoint).M,
                                    (outPoint as IPoint).X,
                                    (outPoint as IPoint).Y,
                                    (outPoint as IPoint).M);

                                (Point as IPoint).M = outPoint.M;
                                PointCollection.UpdatePoint(i, (Point as IPoint));

                                bUpdated = true;
                            }
                            else
                            {
                                double km_begin_tol = km_begin - (TolerantieVormpuntBuitenInterval /1000);
                                double km_eind_tol = km_eind + (TolerantieVormpuntBuitenInterval/1000);

                                if ((this.MarkeerVormpuntBuitenInterval) && !(outPoint.M >= km_begin_tol && outPoint.M < km_eind_tol))
                                {
                                    _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBuitenInterval, this.KleurVormpuntBuitenInterval);
                                }
                            }


                        }

                        if ((bUpdated) && (this.MarkeerVormpuntBijgewerkt))
                        {
                             _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntBijgewerkt, this.KleurVormpuntBijgewerkt);
                        }
                        if (!(bUpdated) && (this.MarkeerVormpuntNietBijgewerkt))
                        {
                            _ArcObjectsHelper.AddGraphicToMap(ArcMap.Document.FocusMap, Point, this.KleurVormpuntNietBijgewerkt, this.KleurVormpuntNietBijgewerkt);
                        }


                    }

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
                        UpdateCursor.UpdateFeature(feature);
                    }
                    else if (!bNietMonotoon)
                    {
                        feature.Shape = (PointCollection as IGeometry);
                        UpdateCursor.UpdateFeature(feature);
                    }

                    featurecounter += 1;
                    this.progress = (100 * featurecounter) / featurecount;
                    feature = UpdateCursor.NextFeature();
                }

            }
            catch (System.Exception ex)
            {
                this.SaveEdits = false;
                throw;
            }
            WorkspaceEdit.StopEditOperation();
            WorkspaceEdit.StopEditing(this.SaveEdits);

        }

        public void LoadSettings()
        {
            // Open de workspace
            try
            {
                try
                {
                    this.FeatureWorkspace = (_ArcObjectsHelper.SDEWorkspaceFromPropertySet("gisserver", "5151", "viewer", "viewer", "", "SDE.DEFAULT") as IFeatureWorkspace);
                }
                catch (System.Exception)
                {
                    this.FeatureWorkspace = _ArcObjectsHelper.GetFeatureWorkspaceFromDirectory(Properties.Settings.Default.inputfolder);
                }


                try
                {
                    this.fcLRS = FeatureWorkspace.OpenFeatureClass(Properties.Settings.Default.lrs);

                }
                catch (Exception)
                {
                    throw new System.Exception(string.Format("De LRS featureclass '{0}' is niet gevonden op de locatie '{1}'", 
                                                             Properties.Settings.Default.lrs,FeatureWorkspace.ToString())); 
                }
                try
                {
                    this.fcRaai = FeatureWorkspace.OpenFeatureClass(Properties.Settings.Default.raai);

                }
                catch (Exception)
                {
                    throw new System.Exception(string.Format("De Raai featureclass '{0}' is niet gevonden op de locatie '{1}'", 
                                                             Properties.Settings.Default.lrs,FeatureWorkspace.ToString())); 
                }

                this.raai_afstand = Properties.Settings.Default.raai_afstand;
                this.raai_sleutel = Properties.Settings.Default.raai_sleutel;


                this.mshape_beginkm = Properties.Settings.Default.mshape_kmbegin;
                this.mshape_eindkm = Properties.Settings.Default.mshape_kmeind;
                this.mshape_sleutel1 = Properties.Settings.Default.mshape_sleutel1;
                this.mshape_sleutel2 = Properties.Settings.Default.mshape_sleutel2;
                this.mshape_maxafstand = Properties.Settings.Default.mshape_maxafstand;
                this.mshape_tolerantie = Properties.Settings.Default.mshape_tolerantie;
                this.AfstandLijnBuitenZoekAfstand = mshape_maxafstand;
                this.AfstandVormpuntBuitenZoekAfstand = mshape_maxafstand;
                this.VerschilVormpuntMetAfwijking = 500;

                this.lrs_sleutel = Properties.Settings.Default.lrs_sleutel;
                this.lrs_selectie = Properties.Settings.Default.lrs_selectie;

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        internal void Show()
        {
            FormKalibreren Form = new FormKalibreren(this);
            Form.ShowDialog();
        }




        public string lrs_selectie { get; set; }

        public string fcLRS_name
        {
            get
            {
                return (fcLRS as IDataset).Workspace.PathName + "\\"  +(fcLRS as IDataset).BrowseName;
            }
        }

    }
}
