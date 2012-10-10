using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KalibreerMShape
{
    public partial class FormKalibreren : Form
    {
        public FormKalibreren(Kalibreerder Kalibreerder)
        {
            InitializeComponent();

            this.KleurVormpuntBijgewerkt.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurVormpuntNietBijgewerkt.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurVormpuntBuitenZoekAfstand.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurLijnBuitenZoekAfstand.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurVormpuntMetAfwijking.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurVormpuntBuitenInterval.Click += new System.EventHandler(this.buttonColors_Click);
            this.KleurLijnNietMonotoon.Click += new System.EventHandler(this.buttonColors_Click);

            this.Kalibreerder = Kalibreerder;
            this.Kalibreerder.ProgressUpdated += Kalibreerder_ProgressUpdated;

            this.lrs_selectie.DataBindings.Add("Text", Kalibreerder, lrs_selectie.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.fcLRS_name.DataBindings.Add("Text", Kalibreerder, fcLRS_name.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.mshape_beginkm.DataBindings.Add("Text", Kalibreerder, mshape_beginkm.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);
            this.mshape_eindkm.DataBindings.Add("Text", Kalibreerder, mshape_eindkm.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);
            this.mshape_maxafstand.DataBindings.Add("Text", Kalibreerder, mshape_maxafstand.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);
            this.mshape_tolerantie.DataBindings.Add("Text", Kalibreerder, mshape_tolerantie.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.mshape_sleutel1.DataBindings.Add("Text", Kalibreerder, mshape_sleutel1.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);
            this.mshape_sleutel2.DataBindings.Add("Text", Kalibreerder, mshape_sleutel2.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);
            this.raai_afstand.DataBindings.Add("Text", Kalibreerder, raai_afstand.Tag.ToString(), false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurVormpuntBijgewerkt.DataBindings.Add("BackColor", Kalibreerder, KleurVormpuntBijgewerkt.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerVormpuntBijgewerkt.DataBindings.Add("Checked", Kalibreerder, MarkeerVormpuntBijgewerkt.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurVormpuntNietBijgewerkt.DataBindings.Add("BackColor", Kalibreerder, KleurVormpuntNietBijgewerkt.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerVormpuntNietBijgewerkt.DataBindings.Add("Checked", Kalibreerder, MarkeerVormpuntNietBijgewerkt.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurLijnNietMonotoon.DataBindings.Add("BackColor", Kalibreerder, KleurLijnNietMonotoon.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerLijnNietMonotoon.DataBindings.Add("Checked", Kalibreerder, MarkeerLijnNietMonotoon.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.OpslaanLijnNietMonotoon.DataBindings.Add("Checked", Kalibreerder, OpslaanLijnNietMonotoon.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurVormpuntBuitenZoekAfstand.DataBindings.Add("BackColor", Kalibreerder, KleurVormpuntBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.AfstandVormpuntBuitenZoekAfstand.DataBindings.Add("Text", Kalibreerder, AfstandVormpuntBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerVormpuntBuitenZoekAfstand.DataBindings.Add("Checked", Kalibreerder, MarkeerVormpuntBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurLijnBuitenZoekAfstand.DataBindings.Add("BackColor", Kalibreerder, KleurLijnBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.AfstandLijnBuitenZoekAfstand.DataBindings.Add("Text", Kalibreerder, AfstandLijnBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerLijnBuitenZoekAfstand.DataBindings.Add("Checked", Kalibreerder, MarkeerLijnBuitenZoekAfstand.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurVormpuntMetAfwijking.DataBindings.Add("BackColor", Kalibreerder, KleurVormpuntMetAfwijking.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.VerschilVormpuntMetAfwijking.DataBindings.Add("Text", Kalibreerder, VerschilVormpuntMetAfwijking.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerVormpuntMetAfwijking.DataBindings.Add("Checked", Kalibreerder, MarkeerVormpuntMetAfwijking.Name, false, DataSourceUpdateMode.OnPropertyChanged);

            this.KleurVormpuntBuitenInterval.DataBindings.Add("BackColor", Kalibreerder, KleurVormpuntBuitenInterval.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.MarkeerVormpuntBuitenInterval.DataBindings.Add("Checked", Kalibreerder, MarkeerVormpuntBuitenInterval.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            this.TolerantieVormpuntBuitenInterval.DataBindings.Add("Text", Kalibreerder, TolerantieVormpuntBuitenInterval.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            

            this.SaveEdits.DataBindings.Add("Checked", Kalibreerder, SaveEdits.Name, false, DataSourceUpdateMode.OnPropertyChanged);

        }

        public Kalibreerder Kalibreerder { get; set; }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                this.Kalibreerder.Kalibreer();
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden", "Foutmelding");

            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        private void Kalibreerder_ProgressUpdated(object sender, EventArgs e)
        {
            this.progressBar.Value = this.Kalibreerder.progress; 
            this.progressBar.Refresh();
        }

        private void buttonColors_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            // MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = (sender as Button).BackColor;

            // Update the text box color if the user clicks OK  
            if (MyDialog.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor  = MyDialog.Color;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lrs_selectie_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
