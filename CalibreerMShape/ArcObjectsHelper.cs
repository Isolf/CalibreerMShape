using ESRI.ArcGIS.Display;
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
    public class ArcObjectsHelper
    {

        public ESRI.ArcGIS.Display.IRgbColor ConvertColor(System.Drawing.Color Color)
        {
            // Zet de default waarden
            ESRI.ArcGIS.Display.IRgbColor RgbColor = new ESRI.ArcGIS.Display.RgbColorClass();
            RgbColor.Red = Color.R;
            RgbColor.Green = Color.G;
            RgbColor.Blue = Color.B;

            return RgbColor;
        }

        #region "Get Shapefile workspace from folder"

        public IFeatureWorkspace GetFeatureWorkspaceFromDirectory(System.String string_ShapefileDirectory)
        {

            System.IO.DirectoryInfo directoryInfo_check = new System.IO.DirectoryInfo(string_ShapefileDirectory);
            if (directoryInfo_check.Exists)
            {

                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IWorkspace workspace = workspaceFactory.OpenFromFile(string_ShapefileDirectory, 0);
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explict Cast
                return featureWorkspace;

            }
            else
            {

                // Not valid directory
                return null;

            }

        }
        #endregion

        #region "Get FeatureClass From Shapefile On Disk"

        /// <summary>
        /// Get the FeatureClass from a Shapefile on disk (hard drive).
        /// </summary>
        /// <param name="string_ShapefileDirectory">A System.String that is the directory where the shapefile is located. Example: "C:\data\USA"</param>
        /// <param name="string_ShapefileName">A System.String that is the shapefile name. Note: the shapefile extension's (.shp, .shx, .dbf, etc.) is not provided! Example: "States"</param>
        /// <returns>An IFeatureClass interface. Nothing (VB.NET) or null (C#) is returned if unsuccessful.</returns>
        /// <remarks></remarks>
        public IFeatureClass GetFeatureClassFromShapefileOnDisk(System.String string_ShapefileDirectory, System.String string_ShapefileName)
        {

            System.IO.DirectoryInfo directoryInfo_check = new System.IO.DirectoryInfo(string_ShapefileDirectory);
            if (directoryInfo_check.Exists)
            {

                //We have a valid directory, proceed

                System.IO.FileInfo fileInfo_check = new System.IO.FileInfo(string_ShapefileDirectory + "\\" + string_ShapefileName + ".shp");
                if (fileInfo_check.Exists)
                {

                    //We have a valid shapefile, proceed

                    IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                    IWorkspace workspace = workspaceFactory.OpenFromFile(string_ShapefileDirectory, 0);
                    IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explict Cast
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(string_ShapefileName);

                    return featureClass;
                }
                else
                {

                    //Not valid shapefile
                    return null;
                }

            }
            else
            {

                // Not valid directory
                return null;

            }

        }
        #endregion

        //SDEWorkspaceFromPropertySet

        // Returns a reference to an existing workspace via a propertyset
        // The connection parameters are passed in as arguements 
        //
        //REFERENCES(REQUIRED)
        //ESRI.ArcGIS.Geodatabase
        //ESRI.ArcGIS.DataSourcesGDB
        public ESRI.ArcGIS.Geodatabase.IWorkspace SDEWorkspaceFromPropertySet(String server, String instance, String user,
                                                    String password, String database, String version)
        {

            // Create and populate the property set
            ESRI.ArcGIS.esriSystem.IPropertySet propertySet = new ESRI.ArcGIS.esriSystem.PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);

            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory2 workspaceFactory;
            workspaceFactory = (ESRI.ArcGIS.Geodatabase.IWorkspaceFactory2)new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
            return workspaceFactory.Open(propertySet, 0);
        }

        
        public IFeatureClass GetFeatureClassOfSelectedFeatureLayerInContentsView()
        {
            IContentsView CurrentContentsView = GetContentsViewFromArcMap(ArcMap.Application, 0);
            IFeatureClass fc = GetFeatureClassOfSelectedFeatureLayerInContentsView(CurrentContentsView);
            if (fc == null) 
            {
                CurrentContentsView = GetContentsViewFromArcMap(ArcMap.Application, 1);
                fc = GetFeatureClassOfSelectedFeatureLayerInContentsView(CurrentContentsView);
            }

            return fc;
        }

        public ESRI.ArcGIS.Carto.IFeatureLayer GetSelectedFeatureLayerInContentsView()
        {
            IContentsView CurrentContentsView = GetContentsViewFromArcMap(ArcMap.Application, 0);
            ESRI.ArcGIS.Carto.IFeatureLayer fl = GetSelectedFeatureLayerInContentsView(CurrentContentsView);
            if (fl == null) 
            {
                CurrentContentsView = GetContentsViewFromArcMap(ArcMap.Application, 1);
                fl = GetSelectedFeatureLayerInContentsView(CurrentContentsView);
            }

            return fl;
        }

        public ESRI.ArcGIS.Carto.IFeatureLayer GetSelectedFeatureLayerInContentsView(ESRI.ArcGIS.ArcMapUI.IContentsView currentContentsView)
        {
            if (currentContentsView == null)
            {
                return null;
            }
            if (currentContentsView.SelectedItem is ESRI.ArcGIS.Carto.IFeatureLayer)
            {
                ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = (ESRI.ArcGIS.Carto.IFeatureLayer)currentContentsView.SelectedItem; // Explicit Cast
                return featureLayer;
            }
            return null;
        }

        #region"Get Contents View from ArcMap"
        // ArcGIS Snippet Title:
        // Get Contents View from ArcMap
        // 
        // Long Description:
        // Get the Contents View (TOC) for ArcMap.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing GetIntersection.
        // 

        ///<summary>Get the Contents View (TOC) for ArcMap.</summary>
        ///
        ///<param name="application">An IApplication interface that is the ArcMap application.</param>
        ///<param name="index">A System.Int32 that is the tab number of the TOC. When specifying the index number: 0 = usually the Display tab, 1 = usually the Source tab.</param>
        /// 
        ///<returns>An IContentsView interface.</returns>
        /// 
        ///<remarks></remarks>
        public ESRI.ArcGIS.ArcMapUI.IContentsView GetContentsViewFromArcMap(ESRI.ArcGIS.Framework.IApplication application, System.Int32 index)
        {
            if (application == null || index < 0 || index > 1)
            {
                return null;
            }
            ESRI.ArcGIS.ArcMapUI.IMxDocument mxDocument = (ESRI.ArcGIS.ArcMapUI.IMxDocument)(application.Document); // Explicit Cast
            ESRI.ArcGIS.ArcMapUI.IContentsView contentsView = mxDocument.get_ContentsView(index); // 0 = usually the Display tab, 1 = usually the Source tab

            return contentsView;
        }
        #endregion

        #region"Get FeatureClass of Selected Feature Layer in Contents View"
        // ArcGIS Snippet Title:
        // Get FeatureClass of Selected Feature Layer in Contents View
        // 
        // Long Description:
        // Returns a reference to the currently selected featureclass from the given contents view.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.Geodatabase
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing GetIntersection.
        // 

        ///<summary>Returns a reference to the currently selected featureclass from the given contents view.</summary>
        ///  
        ///<param name="currentContentsView">An IContentsView interface.</param>
        ///  
        ///<returns>An IFeatureClass interface or Nothing if not found.</returns>
        ///   
        ///<remarks></remarks>
        public ESRI.ArcGIS.Geodatabase.IFeatureClass GetFeatureClassOfSelectedFeatureLayerInContentsView(ESRI.ArcGIS.ArcMapUI.IContentsView currentContentsView)
        {
            if (currentContentsView == null)
            {
                return null;
            }
            if (currentContentsView.SelectedItem is ESRI.ArcGIS.Carto.IFeatureLayer)
            {
                ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = (ESRI.ArcGIS.Carto.IFeatureLayer)currentContentsView.SelectedItem; // Explicit Cast
                ESRI.ArcGIS.Geodatabase.IFeatureClass featureClass = featureLayer.FeatureClass;

                return featureClass;
            }
            return null;
        }
        #endregion



        #region "Add Graphic to Map"

        public void AddGraphicToMap(IMap map, IGeometry geometry, System.Drawing.Color Color, System.Drawing.Color outlineColor)
        {
            this.AddGraphicToMap(map, geometry, ConvertColor(Color), ConvertColor(outlineColor));
        }

        public void AddGraphicToMap(IGeometry geometry)
        {
            this.AddGraphicToMap((ArcMap.Document as IMxDocument).FocusMap, geometry, ConvertColor(System.Drawing.Color.Red), ConvertColor(System.Drawing.Color.Red));
        }

        public void AddGraphicToMap(IGeometry geometry, System.Drawing.Color Color)
        {
            this.AddGraphicToMap((ArcMap.Document as IMxDocument).FocusMap, geometry, ConvertColor(Color), ConvertColor(Color));
        }

        ///<summary>Draw a specified graphic on the map using the supplied colors.</summary>
        ///      
        ///<param name="map">An IMap interface.</param>
        ///<param name="geometry">An IGeometry interface. It can be of the geometry type: esriGeometryPoint, esriGeometryPolyline, or esriGeometryPolygon.</param>
        ///<param name="rgbColor">An IRgbColor interface. The color to draw the geometry.</param>
        ///<param name="outlineRgbColor">An IRgbColor interface. For those geometry's with an outline it will be this color.</param>
        ///      
        ///<remarks>Calling this function will not automatically make the graphics appear in the map area. Refresh the map area after after calling this function with Methods like IActiveView.Refresh or IActiveView.PartialRefresh.</remarks>
        public void AddGraphicToMap(IMap map, IGeometry geometry, IRgbColor rgbColor, IRgbColor outlineRgbColor)
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map; // Explicit Cast
            IElement element = null;
            if ((geometry.GeometryType) == esriGeometryType.esriGeometryPoint)
            {
                // Marker symbols
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = rgbColor;
                simpleMarkerSymbol.Outline = true;
                simpleMarkerSymbol.OutlineColor = outlineRgbColor;
                simpleMarkerSymbol.Size = 15;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;

                IMarkerElement markerElement = new MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol;
                element = (IElement)markerElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == esriGeometryType.esriGeometryPolyline)
            {
                //  Line elements
                ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                simpleLineSymbol.Color = rgbColor;
                simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                simpleLineSymbol.Width = 5;

                ILineElement lineElement = new LineElementClass();
                lineElement.Symbol = simpleLineSymbol;
                element = (IElement)lineElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == esriGeometryType.esriGeometryPolygon)
            {
                // Polygon elements
                ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
                IFillShapeElement fillShapeElement = new PolygonElementClass();
                fillShapeElement.Symbol = simpleFillSymbol;
                element = (IElement)fillShapeElement; // Explicit Cast
            }
            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
        }
        #endregion

        public void InsertPointAtIntersection(ref IPolyline pPolyline, IGeometry pOther, double hmgetal)
        {
            bool SplitHappened = false;
            int newPartIndex = 0;
            int newSegmentIndex = 0;
            int index = 0;
            List<int> indices;
            IPoint Point = null;

            IClone pClone = pPolyline.SpatialReference as IClone;
            if (pClone.IsEqual(pOther.SpatialReference as IClone) == false)
            {
                pOther.Project(pPolyline.SpatialReference);
            }

            ITopologicalOperator pTopoOp = pOther as ITopologicalOperator;
            pTopoOp.Simplify();

            pTopoOp = pPolyline as ITopologicalOperator;
            IGeometry pGeomResult = pTopoOp.Intersect(pOther, esriGeometryDimension.esriGeometry0Dimension);

            indices = new List<int>();
            if ((pGeomResult is IPointCollection) && ((pGeomResult as IPointCollection).PointCount > 0))
            {

                for (int i = 0; i < (pGeomResult as IPointCollection).PointCount; i++)
                {
                    (pPolyline as IPolycurve2).SplitAtPoint((pGeomResult as IPointCollection).get_Point(i), true, false, out SplitHappened, out newPartIndex, out newSegmentIndex);
                    //TODO Zet de measure op het ingevoegde punt, houdt rekening met partindex en segmentindex

                    for (int j = 0; j < newPartIndex; j++)
                    {
                        index += ((pPolyline as IGeometryCollection).get_Geometry(j) as IPointCollection).PointCount;
                    }
                    index += newSegmentIndex;

                    Point = (pPolyline as IPointCollection).get_Point(index);
                    Point.M = hmgetal;
                    (pPolyline as IPointCollection).UpdatePoint(index, Point);

                }

            }

            (pPolyline as ITopologicalOperator2).IsKnownSimple_2 = false;
            (pPolyline as IPolyline4).SimplifyEx(true);

        }



        public void InsertPointAtIntersection2(ref IPolyline pPolyline, IGeometry pOther, double hmgetal)
        {
            bool SplitHappened = false;
            int newPartIndex = 0;
            int newSegmentIndex = 0;
            int index = 0;
            IPoint Point = null;
            IPoint HitPoint = new ESRI.ArcGIS.Geometry.Point();
            double hitDistance = 0;
            int hitPartIndex = 0;
            int hitSegmentIndex = 0;
            bool bRightSide = false;


            ITopologicalOperator5 pTopoOpOther = pOther as ITopologicalOperator5;
            pTopoOpOther.Simplify();

            ITopologicalOperator6 pTopoOpPolyline = pPolyline as ITopologicalOperator6;
            IGeometry pGeomResult = pTopoOpPolyline.IntersectEx(pOther,false, esriGeometryDimension.esriGeometry0Dimension);

            if ((pGeomResult is IPointCollection) && ((pGeomResult as IPointCollection).PointCount > 0))
            {
                for (int i = 0; i < (pGeomResult as IPointCollection).PointCount; i++)
                {
 
                    (pPolyline as IHitTest).HitTest(
                        (pGeomResult as IPointCollection).get_Point(i),
                        10,
                        esriGeometryHitPartType.esriGeometryPartBoundary,
                        HitPoint,
                        ref hitDistance,
                        ref hitPartIndex,
                        ref hitSegmentIndex,
                        ref bRightSide);

                    index = 0;
                    for (int j = 0; j < hitPartIndex; j++)
                    {
                        index += ((pPolyline as IGeometryCollection).get_Geometry(j) as IPointCollection).PointCount;
                    }
                    index += hitSegmentIndex;

                    HitPoint.M = hmgetal;
                    (pPolyline as IPointCollection).AddPoint(HitPoint, after: index); 

                }

            }
            (pPolyline as ITopologicalOperator2).IsKnownSimple_2 = false;
            (pPolyline as IPolyline4).SimplifyEx(true);
        }


        public IPolyline ScaleRaai(ref IPolyline Raai)
        {
            ISegmentCollection Segments = Raai as ISegmentCollection;
            IEnumSegment enumSegment = Segments.EnumSegments;
            ISegment Segment = null;
            ISegment LangsteSegment = null;

            int outPartIndex = 0;
            int SegmentIndex = 0;
            enumSegment.Next(out Segment, ref outPartIndex, ref SegmentIndex);
            LangsteSegment = Segment;

            while (Segment != null)
            {
                if (Segment.Length >= LangsteSegment.Length) { LangsteSegment = (Segment as IClone).Clone() as ISegment; }
                enumSegment.Next(out Segment, ref outPartIndex, ref SegmentIndex);
            }

            IConstructLine line = new Line() as IConstructLine;
            line.ConstructExtended(LangsteSegment as ILine, esriSegmentExtension.esriExtendEmbedded);

            Raai = new Polyline() as IPolyline;
            (Raai as IPointCollection).AddPoint((line as ILine).FromPoint);
            (Raai as IPointCollection).AddPoint((line as ILine).ToPoint);

            return Raai;
        }

        public void ScalePolyline(IPolyline Raai, double scale)
        {
            ITransform2D TransForm2D = Raai as ITransform2D;


            // Get the center point of the envelope.
            IEnvelope envelope = Raai.Envelope;
            IPoint centerPoint = new PointClass();
            centerPoint.X = ((envelope.XMax - envelope.XMin) / 2) + envelope.XMin;
            centerPoint.Y = ((envelope.YMax - envelope.YMin) / 2) + envelope.YMin;

            TransForm2D.Scale(centerPoint, scale, scale);
        }

        public ESRI.ArcGIS.Geodatabase.IField CreateFieldText(string fieldName, int length)
        {
            ESRI.ArcGIS.Geodatabase.IField field = new ESRI.ArcGIS.Geodatabase.FieldClass();

            // create a user defined text field
            ESRI.ArcGIS.Geodatabase.IFieldEdit fieldEdit = (ESRI.ArcGIS.Geodatabase.IFieldEdit)field; // Explicit Cast

            // setup field properties
            fieldEdit.Name_2 = fieldName;
            fieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeString;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.AliasName_2 = fieldName;
            fieldEdit.DefaultValue_2 = "";
            fieldEdit.Editable_2 = true;
            fieldEdit.Length_2 = length;

            return field;
        }

        public ESRI.ArcGIS.Geodatabase.IField CreateFieldInt(string fieldName)
        {
            ESRI.ArcGIS.Geodatabase.IField field = new ESRI.ArcGIS.Geodatabase.FieldClass();

            // create a user defined text field
            ESRI.ArcGIS.Geodatabase.IFieldEdit fieldEdit = (ESRI.ArcGIS.Geodatabase.IFieldEdit)field; // Explicit Cast

            // setup field properties
            fieldEdit.Name_2 = fieldName;
            fieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeInteger;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.AliasName_2 = fieldName;
            fieldEdit.DefaultValue_2 = 0;
            fieldEdit.Editable_2 = true;

            return field;
        }

        public ESRI.ArcGIS.Geodatabase.IField CreateFieldDouble(string fieldName, int precision, int scale)
        {
            ESRI.ArcGIS.Geodatabase.IField field = new ESRI.ArcGIS.Geodatabase.FieldClass();

            // create a user defined text field
            ESRI.ArcGIS.Geodatabase.IFieldEdit fieldEdit = (ESRI.ArcGIS.Geodatabase.IFieldEdit)field; // Explicit Cast

            // setup field properties
            fieldEdit.Name_2 = fieldName;
            fieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeDouble;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.AliasName_2 = fieldName;
            fieldEdit.DefaultValue_2 = 0;
            fieldEdit.Editable_2 = true;
            fieldEdit.Precision_2 = precision;
            fieldEdit.Scale_2 = scale;

            return field;
        }

        #region"Create Table"
        // ArcGIS Snippet Title:
        // Create Table
        // 
        // Long Description:
        // Creates a dataset in a workspace.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Geodatabase
        // ESRI.ArcGIS.Geometry
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // ArcGIS Engine
        // ArcGIS Server
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Uitvoeren.
        // 

        ///<summary>Creates a table with some default fields.</summary>
        /// 
        ///<param name="workspace">An IWorkspace2 interface</param>
        ///<param name="tableName">A System.String of the table name in the workspace. Example: "owners"</param>
        ///<param name="fields">An IFields interface or Nothing</param>
        ///  
        ///<returns>An ITable interface or Nothing</returns>
        ///  
        ///<remarks>
        ///Notes:
        ///(1) If an IFields interface is supplied for the 'fields' collection it will be used to create the
        ///    table. If a Nothing value is supplied for the 'fields' collection, a table will be created using 
        ///    default values in the method.
        ///(2) If a table with the supplied 'tableName' exists in the workspace an ITable will be returned.
        ///    if table does not exit a new one will be created.
        ///</remarks>
        public ESRI.ArcGIS.Geodatabase.ITable CreateOrOpenTableLog(ESRI.ArcGIS.Geodatabase.IWorkspace2 workspace, System.String tableName, ESRI.ArcGIS.Geodatabase.IFields fields)
        {
            // create the behavior clasid for the featureclass
            ESRI.ArcGIS.esriSystem.UID uid = new ESRI.ArcGIS.esriSystem.UIDClass();

            if (workspace == null) return null; // valid feature workspace not passed in as an argument to the method

            ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspace; // Explicit Cast
            ESRI.ArcGIS.Geodatabase.ITable table;

            if (workspace.get_NameExists(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTTable, tableName))
            {
                // table with that name already exists return that table 
                table = featureWorkspace.OpenTable(tableName);
                return table;
            }

            uid.Value = "esriGeoDatabase.Object";

            ESRI.ArcGIS.Geodatabase.IObjectClassDescription objectClassDescription = new ESRI.ArcGIS.Geodatabase.ObjectClassDescriptionClass();

            // if a fields collection is not passed in then supply our own
            if (fields == null)
            {
                // create the fields using the required fields method
                fields = objectClassDescription.RequiredFields;
                ESRI.ArcGIS.Geodatabase.IFieldsEdit fieldsEdit = (ESRI.ArcGIS.Geodatabase.IFieldsEdit)fields; // Explicit Cast

                fieldsEdit.AddField(this.CreateFieldInt("ID"));
                fieldsEdit.AddField(this.CreateFieldInt("index"));
                fieldsEdit.AddField(this.CreateFieldDouble("X_From", 8, 2));
                fieldsEdit.AddField(this.CreateFieldDouble("Y_From", 8, 2));
                fieldsEdit.AddField(this.CreateFieldDouble("M_From", 8, 2));
                fieldsEdit.AddField(this.CreateFieldDouble("X_To", 8, 2));
                fieldsEdit.AddField(this.CreateFieldDouble("Y_To", 8, 2));
                fieldsEdit.AddField(this.CreateFieldDouble("M_To", 8, 2));


                // add field to field collection
                fields = (ESRI.ArcGIS.Geodatabase.IFields)fieldsEdit; // Explicit Cast
            }

            // Use IFieldChecker to create a validated fields collection.
            ESRI.ArcGIS.Geodatabase.IFieldChecker fieldChecker = new ESRI.ArcGIS.Geodatabase.FieldCheckerClass();
            ESRI.ArcGIS.Geodatabase.IEnumFieldError enumFieldError = null;
            ESRI.ArcGIS.Geodatabase.IFields validatedFields = null;
            fieldChecker.ValidateWorkspace = (ESRI.ArcGIS.Geodatabase.IWorkspace)workspace;
            fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

            // The enumFieldError enumerator can be inspected at this point to determine 
            // which fields were modified during validation.


            // create and return the table
            table = featureWorkspace.CreateTable(tableName, validatedFields, uid, null, "");

            return table;
        }

        public void LogRecord(ITable table, int ID, int index, double X_From, double Y_From, double M_From, double X_To, double Y_To, double M_To)
        {
            ICursor InsertCursor = table.Insert(false);
            try
            {
                IRowBuffer rowBuffer = table.CreateRowBuffer();
                rowBuffer.set_Value(rowBuffer.Fields.FindField("ID"), ID);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("index"), index);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("X_From"), X_From);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("Y_From"), Y_From);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("M_From"), M_From);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("X_To"), X_To);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("Y_To"), Y_To);
                rowBuffer.set_Value(rowBuffer.Fields.FindField("M_To"), M_To);

                InsertCursor.InsertRow(rowBuffer);
                InsertCursor.Flush();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(InsertCursor);
            }
        }


        #endregion


 
    }
}
