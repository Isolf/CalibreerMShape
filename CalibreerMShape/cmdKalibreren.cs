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
using System.Windows.Forms; 

namespace KalibreerMShape
{
    public class cmdKalibreren : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Kalibreerder Kalibreerder { get; set; }
        public ArcObjectsHelper ArcObjectsHelper { get; set; }

        public cmdKalibreren()
        {
            this.ArcObjectsHelper = new ArcObjectsHelper();
            this.Kalibreerder = new Kalibreerder();
        }


        protected override void OnClick()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; 
            try
            {
                ArcMap.Application.CurrentTool = null;

                IFeatureClass fcMShape = ArcObjectsHelper.GetFeatureClassFromActiveLayerInContentsView();
                if (fcMShape != null)
                {
                    this.Kalibreerder.fcMShape = fcMShape;
                    this.Kalibreerder.LoadSettings();
                    this.Kalibreerder.Show();

                    (ArcMap.Document.FocusMap as IActiveView).Refresh();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Voeg een mshape toe aan de Table of Contents en maak deze actief.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("{0}\r\n{1}","Er is een onverwachte fout opgetreden met foutbericht:",ex.Message));
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; 
            }
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }



    }

}
