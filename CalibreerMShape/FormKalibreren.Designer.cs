namespace KalibreerMShape
{
    partial class FormKalibreren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdAnnuleren = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbKalibreren = new System.Windows.Forms.ComboBox();
            this.LogVormpunten = new System.Windows.Forms.CheckBox();
            this.SaveEdits = new System.Windows.Forms.CheckBox();
            this.grpMshape = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mshape_sleutel2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mshape_sleutel1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpVW_HECTOMETERRAAI = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.raai_afstand = new System.Windows.Forms.TextBox();
            this.raai_selectie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpVW_LRS_SPOORHARTLIJN = new System.Windows.Forms.GroupBox();
            this.mshape_tolerantie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mshape_maxafstand = new System.Windows.Forms.TextBox();
            this.lrs_selectie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KleurRaaiMetOngeldigeHmwaarde = new System.Windows.Forms.Button();
            this.MarkeerRaaiMetOngeldigeHmwaarde = new System.Windows.Forms.CheckBox();
            this.OpslaanLijnNietMonotoon = new System.Windows.Forms.CheckBox();
            this.KleurLijnNietMonotoon = new System.Windows.Forms.Button();
            this.MarkeerLijnNietMonotoon = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntNietBijgewerkt = new System.Windows.Forms.Button();
            this.MarkeerVormpuntNietBijgewerkt = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntBijgewerkt = new System.Windows.Forms.Button();
            this.MarkeerVormpuntBijgewerkt = new System.Windows.Forms.CheckBox();
            this.TolerantieVormpuntBuitenInterval = new System.Windows.Forms.TextBox();
            this.KleurVormpuntBuitenInterval = new System.Windows.Forms.Button();
            this.MarkeerVormpuntBuitenInterval = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntMetAfwijking = new System.Windows.Forms.Button();
            this.VerschilVormpuntMetAfwijking = new System.Windows.Forms.TextBox();
            this.MarkeerVormpuntMetAfwijking = new System.Windows.Forms.CheckBox();
            this.KleurLijnBuitenZoekAfstand = new System.Windows.Forms.Button();
            this.AfstandLijnBuitenZoekAfstand = new System.Windows.Forms.TextBox();
            this.MarkeerLijnBuitenZoekAfstand = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntBuitenZoekAfstand = new System.Windows.Forms.Button();
            this.AfstandVormpuntBuitenZoekAfstand = new System.Windows.Forms.TextBox();
            this.MarkeerVormpuntBuitenZoekAfstand = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpMshape.SuspendLayout();
            this.grpVW_HECTOMETERRAAI.SuspendLayout();
            this.grpVW_LRS_SPOORHARTLIJN.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Location = new System.Drawing.Point(635, 389);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdAnnuleren
            // 
            this.cmdAnnuleren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAnnuleren.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAnnuleren.Location = new System.Drawing.Point(554, 389);
            this.cmdAnnuleren.Name = "cmdAnnuleren";
            this.cmdAnnuleren.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuleren.TabIndex = 2;
            this.cmdAnnuleren.Text = "Annuleren";
            this.cmdAnnuleren.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 371);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.grpMshape);
            this.tabPage1.Controls.Add(this.grpVW_HECTOMETERRAAI);
            this.tabPage1.Controls.Add(this.grpVW_LRS_SPOORHARTLIJN);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Instellingen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbKalibreren);
            this.groupBox2.Controls.Add(this.LogVormpunten);
            this.groupBox2.Controls.Add(this.SaveEdits);
            this.groupBox2.Location = new System.Drawing.Point(10, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 109);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instellingen Kalibreren";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Kalibreren op basis van:";
            // 
            // cmbKalibreren
            // 
            this.cmbKalibreren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKalibreren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKalibreren.FormattingEnabled = true;
            this.cmbKalibreren.Items.AddRange(new object[] {
            "VW_LRS_SPOORHARTLIJN",
            "VW_HECTOMETERRAAI"});
            this.cmbKalibreren.Location = new System.Drawing.Point(283, 19);
            this.cmbKalibreren.Name = "cmbKalibreren";
            this.cmbKalibreren.Size = new System.Drawing.Size(389, 21);
            this.cmbKalibreren.TabIndex = 13;
            this.cmbKalibreren.SelectedIndexChanged += new System.EventHandler(this.cmbKalibreren_SelectedIndexChanged);
            // 
            // LogVormpunten
            // 
            this.LogVormpunten.Location = new System.Drawing.Point(6, 45);
            this.LogVormpunten.Name = "LogVormpunten";
            this.LogVormpunten.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LogVormpunten.Size = new System.Drawing.Size(292, 18);
            this.LogVormpunten.TabIndex = 12;
            this.LogVormpunten.Text = "Vormpunten loggen naar tabel \'logtable\'";
            this.LogVormpunten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LogVormpunten.UseVisualStyleBackColor = true;
            // 
            // SaveEdits
            // 
            this.SaveEdits.Location = new System.Drawing.Point(6, 71);
            this.SaveEdits.Name = "SaveEdits";
            this.SaveEdits.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SaveEdits.Size = new System.Drawing.Size(292, 18);
            this.SaveEdits.TabIndex = 11;
            this.SaveEdits.Text = "Edits opslaan";
            this.SaveEdits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveEdits.UseVisualStyleBackColor = true;
            // 
            // grpMshape
            // 
            this.grpMshape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMshape.Controls.Add(this.label6);
            this.grpMshape.Controls.Add(this.mshape_sleutel2);
            this.grpMshape.Controls.Add(this.label4);
            this.grpMshape.Controls.Add(this.mshape_sleutel1);
            this.grpMshape.Controls.Add(this.label3);
            this.grpMshape.Location = new System.Drawing.Point(9, 13);
            this.grpMshape.Name = "grpMshape";
            this.grpMshape.Size = new System.Drawing.Size(679, 83);
            this.grpMshape.TabIndex = 5;
            this.grpMshape.TabStop = false;
            this.grpMshape.Text = "M-shape instellingen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Selectie attribuut {0}:";
            // 
            // mshape_sleutel2
            // 
            this.mshape_sleutel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_sleutel2.Location = new System.Drawing.Point(284, 47);
            this.mshape_sleutel2.Name = "mshape_sleutel2";
            this.mshape_sleutel2.Size = new System.Drawing.Size(389, 20);
            this.mshape_sleutel2.TabIndex = 7;
            this.mshape_sleutel2.Tag = "mshape_sleutel2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selectie attribuut {1}:";
            // 
            // mshape_sleutel1
            // 
            this.mshape_sleutel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_sleutel1.Location = new System.Drawing.Point(284, 19);
            this.mshape_sleutel1.Name = "mshape_sleutel1";
            this.mshape_sleutel1.Size = new System.Drawing.Size(389, 20);
            this.mshape_sleutel1.TabIndex = 5;
            this.mshape_sleutel1.Tag = "mshape_sleutel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // grpVW_HECTOMETERRAAI
            // 
            this.grpVW_HECTOMETERRAAI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVW_HECTOMETERRAAI.Controls.Add(this.label5);
            this.grpVW_HECTOMETERRAAI.Controls.Add(this.raai_afstand);
            this.grpVW_HECTOMETERRAAI.Controls.Add(this.raai_selectie);
            this.grpVW_HECTOMETERRAAI.Controls.Add(this.label7);
            this.grpVW_HECTOMETERRAAI.Controls.Add(this.label11);
            this.grpVW_HECTOMETERRAAI.Location = new System.Drawing.Point(388, 224);
            this.grpVW_HECTOMETERRAAI.Name = "grpVW_HECTOMETERRAAI";
            this.grpVW_HECTOMETERRAAI.Size = new System.Drawing.Size(210, 107);
            this.grpVW_HECTOMETERRAAI.TabIndex = 8;
            this.grpVW_HECTOMETERRAAI.TabStop = false;
            this.grpVW_HECTOMETERRAAI.Text = "VW_HECTOMETERRAAI instellingen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-316, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Maximale zoekafstand spoorhartlijn (m):";
            // 
            // raai_afstand
            // 
            this.raai_afstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raai_afstand.Location = new System.Drawing.Point(275, 45);
            this.raai_afstand.Name = "raai_afstand";
            this.raai_afstand.Size = new System.Drawing.Size(0, 20);
            this.raai_afstand.TabIndex = 13;
            this.raai_afstand.Tag = "raai_afstand";
            // 
            // raai_selectie
            // 
            this.raai_selectie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raai_selectie.Location = new System.Drawing.Point(275, 19);
            this.raai_selectie.Name = "raai_selectie";
            this.raai_selectie.Size = new System.Drawing.Size(0, 20);
            this.raai_selectie.TabIndex = 11;
            this.raai_selectie.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Maximale zoekafstand raaien (m):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Raai selectie";
            // 
            // grpVW_LRS_SPOORHARTLIJN
            // 
            this.grpVW_LRS_SPOORHARTLIJN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.mshape_tolerantie);
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.label9);
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.label10);
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.mshape_maxafstand);
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.lrs_selectie);
            this.grpVW_LRS_SPOORHARTLIJN.Controls.Add(this.label8);
            this.grpVW_LRS_SPOORHARTLIJN.Location = new System.Drawing.Point(10, 224);
            this.grpVW_LRS_SPOORHARTLIJN.Name = "grpVW_LRS_SPOORHARTLIJN";
            this.grpVW_LRS_SPOORHARTLIJN.Size = new System.Drawing.Size(331, 107);
            this.grpVW_LRS_SPOORHARTLIJN.TabIndex = 7;
            this.grpVW_LRS_SPOORHARTLIJN.TabStop = false;
            this.grpVW_LRS_SPOORHARTLIJN.Text = "VW_LRS_SPOORHARTLIJN instellingen";
            // 
            // mshape_tolerantie
            // 
            this.mshape_tolerantie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_tolerantie.Location = new System.Drawing.Point(275, 74);
            this.mshape_tolerantie.Name = "mshape_tolerantie";
            this.mshape_tolerantie.Size = new System.Drawing.Size(127, 20);
            this.mshape_tolerantie.TabIndex = 15;
            this.mshape_tolerantie.Tag = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Maximale zoekafstand spoorhartlijn (m):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tolerantie kilometer interval (m):";
            // 
            // mshape_maxafstand
            // 
            this.mshape_maxafstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_maxafstand.Location = new System.Drawing.Point(275, 46);
            this.mshape_maxafstand.Name = "mshape_maxafstand";
            this.mshape_maxafstand.Size = new System.Drawing.Size(127, 20);
            this.mshape_maxafstand.TabIndex = 12;
            this.mshape_maxafstand.Tag = "mshape_maxafstand";
            // 
            // lrs_selectie
            // 
            this.lrs_selectie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lrs_selectie.Location = new System.Drawing.Point(275, 19);
            this.lrs_selectie.Name = "lrs_selectie";
            this.lrs_selectie.Size = new System.Drawing.Size(127, 20);
            this.lrs_selectie.TabIndex = 9;
            this.lrs_selectie.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "LRS selectie";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Markeringen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.KleurRaaiMetOngeldigeHmwaarde);
            this.groupBox3.Controls.Add(this.MarkeerRaaiMetOngeldigeHmwaarde);
            this.groupBox3.Controls.Add(this.OpslaanLijnNietMonotoon);
            this.groupBox3.Controls.Add(this.KleurLijnNietMonotoon);
            this.groupBox3.Controls.Add(this.MarkeerLijnNietMonotoon);
            this.groupBox3.Controls.Add(this.KleurVormpuntNietBijgewerkt);
            this.groupBox3.Controls.Add(this.MarkeerVormpuntNietBijgewerkt);
            this.groupBox3.Controls.Add(this.KleurVormpuntBijgewerkt);
            this.groupBox3.Controls.Add(this.MarkeerVormpuntBijgewerkt);
            this.groupBox3.Controls.Add(this.TolerantieVormpuntBuitenInterval);
            this.groupBox3.Controls.Add(this.KleurVormpuntBuitenInterval);
            this.groupBox3.Controls.Add(this.MarkeerVormpuntBuitenInterval);
            this.groupBox3.Controls.Add(this.KleurVormpuntMetAfwijking);
            this.groupBox3.Controls.Add(this.VerschilVormpuntMetAfwijking);
            this.groupBox3.Controls.Add(this.MarkeerVormpuntMetAfwijking);
            this.groupBox3.Controls.Add(this.KleurLijnBuitenZoekAfstand);
            this.groupBox3.Controls.Add(this.AfstandLijnBuitenZoekAfstand);
            this.groupBox3.Controls.Add(this.MarkeerLijnBuitenZoekAfstand);
            this.groupBox3.Controls.Add(this.KleurVormpuntBuitenZoekAfstand);
            this.groupBox3.Controls.Add(this.AfstandVormpuntBuitenZoekAfstand);
            this.groupBox3.Controls.Add(this.MarkeerVormpuntBuitenZoekAfstand);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 339);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // KleurRaaiMetOngeldigeHmwaarde
            // 
            this.KleurRaaiMetOngeldigeHmwaarde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurRaaiMetOngeldigeHmwaarde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurRaaiMetOngeldigeHmwaarde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurRaaiMetOngeldigeHmwaarde.Location = new System.Drawing.Point(653, 290);
            this.KleurRaaiMetOngeldigeHmwaarde.Name = "KleurRaaiMetOngeldigeHmwaarde";
            this.KleurRaaiMetOngeldigeHmwaarde.Size = new System.Drawing.Size(27, 23);
            this.KleurRaaiMetOngeldigeHmwaarde.TabIndex = 25;
            this.KleurRaaiMetOngeldigeHmwaarde.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurRaaiMetOngeldigeHmwaarde.UseVisualStyleBackColor = false;
            // 
            // MarkeerRaaiMetOngeldigeHmwaarde
            // 
            this.MarkeerRaaiMetOngeldigeHmwaarde.AutoSize = true;
            this.MarkeerRaaiMetOngeldigeHmwaarde.Location = new System.Drawing.Point(7, 294);
            this.MarkeerRaaiMetOngeldigeHmwaarde.Name = "MarkeerRaaiMetOngeldigeHmwaarde";
            this.MarkeerRaaiMetOngeldigeHmwaarde.Size = new System.Drawing.Size(245, 17);
            this.MarkeerRaaiMetOngeldigeHmwaarde.TabIndex = 24;
            this.MarkeerRaaiMetOngeldigeHmwaarde.Text = "Markeer raaien met een ongeldige hm-waarde:";
            this.MarkeerRaaiMetOngeldigeHmwaarde.UseVisualStyleBackColor = true;
            // 
            // OpslaanLijnNietMonotoon
            // 
            this.OpslaanLijnNietMonotoon.AutoSize = true;
            this.OpslaanLijnNietMonotoon.Location = new System.Drawing.Point(6, 121);
            this.OpslaanLijnNietMonotoon.Name = "OpslaanLijnNietMonotoon";
            this.OpslaanLijnNietMonotoon.Size = new System.Drawing.Size(445, 17);
            this.OpslaanLijnNietMonotoon.TabIndex = 23;
            this.OpslaanLijnNietMonotoon.Text = "Sla lijnen die na calibratie niet een monotoon oplopend of aflopende measure hebb" +
                "en op.";
            this.OpslaanLijnNietMonotoon.UseVisualStyleBackColor = true;
            // 
            // KleurLijnNietMonotoon
            // 
            this.KleurLijnNietMonotoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurLijnNietMonotoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurLijnNietMonotoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurLijnNietMonotoon.Location = new System.Drawing.Point(652, 85);
            this.KleurLijnNietMonotoon.Name = "KleurLijnNietMonotoon";
            this.KleurLijnNietMonotoon.Size = new System.Drawing.Size(27, 23);
            this.KleurLijnNietMonotoon.TabIndex = 22;
            this.KleurLijnNietMonotoon.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurLijnNietMonotoon.UseVisualStyleBackColor = false;
            // 
            // MarkeerLijnNietMonotoon
            // 
            this.MarkeerLijnNietMonotoon.AutoSize = true;
            this.MarkeerLijnNietMonotoon.Location = new System.Drawing.Point(6, 89);
            this.MarkeerLijnNietMonotoon.Name = "MarkeerLijnNietMonotoon";
            this.MarkeerLijnNietMonotoon.Size = new System.Drawing.Size(439, 17);
            this.MarkeerLijnNietMonotoon.TabIndex = 21;
            this.MarkeerLijnNietMonotoon.Text = "Markeer lijnen die na calibratie niet monotoon oplopende of aflopende measure heb" +
                "ben.";
            this.MarkeerLijnNietMonotoon.UseVisualStyleBackColor = true;
            // 
            // KleurVormpuntNietBijgewerkt
            // 
            this.KleurVormpuntNietBijgewerkt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntNietBijgewerkt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurVormpuntNietBijgewerkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntNietBijgewerkt.Location = new System.Drawing.Point(652, 52);
            this.KleurVormpuntNietBijgewerkt.Name = "KleurVormpuntNietBijgewerkt";
            this.KleurVormpuntNietBijgewerkt.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntNietBijgewerkt.TabIndex = 20;
            this.KleurVormpuntNietBijgewerkt.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurVormpuntNietBijgewerkt.UseVisualStyleBackColor = false;
            // 
            // MarkeerVormpuntNietBijgewerkt
            // 
            this.MarkeerVormpuntNietBijgewerkt.AutoSize = true;
            this.MarkeerVormpuntNietBijgewerkt.Location = new System.Drawing.Point(6, 56);
            this.MarkeerVormpuntNietBijgewerkt.Name = "MarkeerVormpuntNietBijgewerkt";
            this.MarkeerVormpuntNietBijgewerkt.Size = new System.Drawing.Size(230, 17);
            this.MarkeerVormpuntNietBijgewerkt.TabIndex = 18;
            this.MarkeerVormpuntNietBijgewerkt.Text = "Markeer vormpunten die niet zijn bijgewerkt";
            this.MarkeerVormpuntNietBijgewerkt.UseVisualStyleBackColor = true;
            // 
            // KleurVormpuntBijgewerkt
            // 
            this.KleurVormpuntBijgewerkt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntBijgewerkt.BackColor = System.Drawing.Color.Red;
            this.KleurVormpuntBijgewerkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntBijgewerkt.Location = new System.Drawing.Point(652, 19);
            this.KleurVormpuntBijgewerkt.Name = "KleurVormpuntBijgewerkt";
            this.KleurVormpuntBijgewerkt.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntBijgewerkt.TabIndex = 17;
            this.KleurVormpuntBijgewerkt.Tag = "";
            this.KleurVormpuntBijgewerkt.UseVisualStyleBackColor = false;
            // 
            // MarkeerVormpuntBijgewerkt
            // 
            this.MarkeerVormpuntBijgewerkt.AutoSize = true;
            this.MarkeerVormpuntBijgewerkt.Location = new System.Drawing.Point(6, 23);
            this.MarkeerVormpuntBijgewerkt.Name = "MarkeerVormpuntBijgewerkt";
            this.MarkeerVormpuntBijgewerkt.Size = new System.Drawing.Size(210, 17);
            this.MarkeerVormpuntBijgewerkt.TabIndex = 15;
            this.MarkeerVormpuntBijgewerkt.Text = "Markeer vormpunten die zijn bijgewerkt";
            this.MarkeerVormpuntBijgewerkt.UseVisualStyleBackColor = true;
            // 
            // TolerantieVormpuntBuitenInterval
            // 
            this.TolerantieVormpuntBuitenInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TolerantieVormpuntBuitenInterval.Location = new System.Drawing.Point(580, 258);
            this.TolerantieVormpuntBuitenInterval.Name = "TolerantieVormpuntBuitenInterval";
            this.TolerantieVormpuntBuitenInterval.Size = new System.Drawing.Size(58, 20);
            this.TolerantieVormpuntBuitenInterval.TabIndex = 14;
            this.TolerantieVormpuntBuitenInterval.Tag = "";
            // 
            // KleurVormpuntBuitenInterval
            // 
            this.KleurVormpuntBuitenInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntBuitenInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurVormpuntBuitenInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntBuitenInterval.Location = new System.Drawing.Point(652, 257);
            this.KleurVormpuntBuitenInterval.Name = "KleurVormpuntBuitenInterval";
            this.KleurVormpuntBuitenInterval.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntBuitenInterval.TabIndex = 13;
            this.KleurVormpuntBuitenInterval.Tag = "";
            this.KleurVormpuntBuitenInterval.UseVisualStyleBackColor = false;
            // 
            // MarkeerVormpuntBuitenInterval
            // 
            this.MarkeerVormpuntBuitenInterval.AutoSize = true;
            this.MarkeerVormpuntBuitenInterval.Location = new System.Drawing.Point(6, 261);
            this.MarkeerVormpuntBuitenInterval.Name = "MarkeerVormpuntBuitenInterval";
            this.MarkeerVormpuntBuitenInterval.Size = new System.Drawing.Size(557, 17);
            this.MarkeerVormpuntBuitenInterval.TabIndex = 11;
            this.MarkeerVormpuntBuitenInterval.Text = "Markeer punten waarbij de gevonden measure meer dan opgegeven tolerantie buiten h" +
                "et interval van de lijn valt.";
            this.MarkeerVormpuntBuitenInterval.UseVisualStyleBackColor = true;
            // 
            // KleurVormpuntMetAfwijking
            // 
            this.KleurVormpuntMetAfwijking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntMetAfwijking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurVormpuntMetAfwijking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntMetAfwijking.Location = new System.Drawing.Point(652, 223);
            this.KleurVormpuntMetAfwijking.Name = "KleurVormpuntMetAfwijking";
            this.KleurVormpuntMetAfwijking.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntMetAfwijking.TabIndex = 9;
            this.KleurVormpuntMetAfwijking.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurVormpuntMetAfwijking.UseVisualStyleBackColor = false;
            // 
            // VerschilVormpuntMetAfwijking
            // 
            this.VerschilVormpuntMetAfwijking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VerschilVormpuntMetAfwijking.Location = new System.Drawing.Point(580, 225);
            this.VerschilVormpuntMetAfwijking.Name = "VerschilVormpuntMetAfwijking";
            this.VerschilVormpuntMetAfwijking.Size = new System.Drawing.Size(58, 20);
            this.VerschilVormpuntMetAfwijking.TabIndex = 8;
            this.VerschilVormpuntMetAfwijking.Tag = "AfstandLijnBuitenZoekAfstand";
            // 
            // MarkeerVormpuntMetAfwijking
            // 
            this.MarkeerVormpuntMetAfwijking.AutoSize = true;
            this.MarkeerVormpuntMetAfwijking.Location = new System.Drawing.Point(6, 227);
            this.MarkeerVormpuntMetAfwijking.Name = "MarkeerVormpuntMetAfwijking";
            this.MarkeerVormpuntMetAfwijking.Size = new System.Drawing.Size(442, 17);
            this.MarkeerVormpuntMetAfwijking.TabIndex = 7;
            this.MarkeerVormpuntMetAfwijking.Text = "Markeer punten waarvoor het verschil tussen oude en nieuwe measure groter is dan " +
                "(m):";
            this.MarkeerVormpuntMetAfwijking.UseVisualStyleBackColor = true;
            // 
            // KleurLijnBuitenZoekAfstand
            // 
            this.KleurLijnBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurLijnBuitenZoekAfstand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurLijnBuitenZoekAfstand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurLijnBuitenZoekAfstand.Location = new System.Drawing.Point(652, 188);
            this.KleurLijnBuitenZoekAfstand.Name = "KleurLijnBuitenZoekAfstand";
            this.KleurLijnBuitenZoekAfstand.Size = new System.Drawing.Size(27, 23);
            this.KleurLijnBuitenZoekAfstand.TabIndex = 6;
            this.KleurLijnBuitenZoekAfstand.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurLijnBuitenZoekAfstand.UseVisualStyleBackColor = false;
            // 
            // AfstandLijnBuitenZoekAfstand
            // 
            this.AfstandLijnBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AfstandLijnBuitenZoekAfstand.Location = new System.Drawing.Point(580, 190);
            this.AfstandLijnBuitenZoekAfstand.Name = "AfstandLijnBuitenZoekAfstand";
            this.AfstandLijnBuitenZoekAfstand.Size = new System.Drawing.Size(58, 20);
            this.AfstandLijnBuitenZoekAfstand.TabIndex = 5;
            this.AfstandLijnBuitenZoekAfstand.Tag = "AfstandLijnBuitenZoekAfstand";
            // 
            // MarkeerLijnBuitenZoekAfstand
            // 
            this.MarkeerLijnBuitenZoekAfstand.AutoSize = true;
            this.MarkeerLijnBuitenZoekAfstand.Location = new System.Drawing.Point(6, 192);
            this.MarkeerLijnBuitenZoekAfstand.Name = "MarkeerLijnBuitenZoekAfstand";
            this.MarkeerLijnBuitenZoekAfstand.Size = new System.Drawing.Size(390, 17);
            this.MarkeerLijnBuitenZoekAfstand.TabIndex = 4;
            this.MarkeerLijnBuitenZoekAfstand.Text = "Markeer lijnen waarvoor geen spoorhartlijn gevonden kan worden binnen (m):";
            this.MarkeerLijnBuitenZoekAfstand.UseVisualStyleBackColor = true;
            // 
            // KleurVormpuntBuitenZoekAfstand
            // 
            this.KleurVormpuntBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntBuitenZoekAfstand.BackColor = System.Drawing.Color.Red;
            this.KleurVormpuntBuitenZoekAfstand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntBuitenZoekAfstand.Location = new System.Drawing.Point(652, 155);
            this.KleurVormpuntBuitenZoekAfstand.Name = "KleurVormpuntBuitenZoekAfstand";
            this.KleurVormpuntBuitenZoekAfstand.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntBuitenZoekAfstand.TabIndex = 3;
            this.KleurVormpuntBuitenZoekAfstand.Tag = "KleurVormpuntBuitenZoekAfstand";
            this.KleurVormpuntBuitenZoekAfstand.UseVisualStyleBackColor = false;
            // 
            // AfstandVormpuntBuitenZoekAfstand
            // 
            this.AfstandVormpuntBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AfstandVormpuntBuitenZoekAfstand.Location = new System.Drawing.Point(580, 157);
            this.AfstandVormpuntBuitenZoekAfstand.Name = "AfstandVormpuntBuitenZoekAfstand";
            this.AfstandVormpuntBuitenZoekAfstand.Size = new System.Drawing.Size(58, 20);
            this.AfstandVormpuntBuitenZoekAfstand.TabIndex = 2;
            this.AfstandVormpuntBuitenZoekAfstand.Tag = "AfstandVormpuntBuitenZoekAfstand";
            // 
            // MarkeerVormpuntBuitenZoekAfstand
            // 
            this.MarkeerVormpuntBuitenZoekAfstand.AutoSize = true;
            this.MarkeerVormpuntBuitenZoekAfstand.Location = new System.Drawing.Point(6, 159);
            this.MarkeerVormpuntBuitenZoekAfstand.Name = "MarkeerVormpuntBuitenZoekAfstand";
            this.MarkeerVormpuntBuitenZoekAfstand.Size = new System.Drawing.Size(399, 17);
            this.MarkeerVormpuntBuitenZoekAfstand.TabIndex = 1;
            this.MarkeerVormpuntBuitenZoekAfstand.Text = "Markeer punten waarvoor geen spoorhartlijn gevonden kan worden binnen (m):";
            this.MarkeerVormpuntBuitenZoekAfstand.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(9, 389);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(539, 23);
            this.progressBar.TabIndex = 4;
            // 
            // FormKalibreren
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdAnnuleren;
            this.ClientSize = new System.Drawing.Size(723, 424);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdAnnuleren);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormKalibreren";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kalibreren m-shape";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpMshape.ResumeLayout(false);
            this.grpMshape.PerformLayout();
            this.grpVW_HECTOMETERRAAI.ResumeLayout(false);
            this.grpVW_HECTOMETERRAAI.PerformLayout();
            this.grpVW_LRS_SPOORHARTLIJN.ResumeLayout(false);
            this.grpVW_LRS_SPOORHARTLIJN.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdAnnuleren;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpMshape;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mshape_sleutel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mshape_sleutel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox AfstandVormpuntBuitenZoekAfstand;
        private System.Windows.Forms.CheckBox MarkeerVormpuntBuitenZoekAfstand;
        private System.Windows.Forms.Button KleurVormpuntBuitenZoekAfstand;
        private System.Windows.Forms.Button KleurLijnBuitenZoekAfstand;
        private System.Windows.Forms.TextBox AfstandLijnBuitenZoekAfstand;
        private System.Windows.Forms.CheckBox MarkeerLijnBuitenZoekAfstand;
        private System.Windows.Forms.Button KleurVormpuntMetAfwijking;
        private System.Windows.Forms.TextBox VerschilVormpuntMetAfwijking;
        private System.Windows.Forms.CheckBox MarkeerVormpuntMetAfwijking;
        private System.Windows.Forms.Button KleurVormpuntBuitenInterval;
        private System.Windows.Forms.CheckBox MarkeerVormpuntBuitenInterval;
        private System.Windows.Forms.TextBox TolerantieVormpuntBuitenInterval;
        private System.Windows.Forms.GroupBox grpVW_LRS_SPOORHARTLIJN;
        private System.Windows.Forms.TextBox lrs_selectie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button KleurVormpuntNietBijgewerkt;
        private System.Windows.Forms.CheckBox MarkeerVormpuntNietBijgewerkt;
        private System.Windows.Forms.Button KleurVormpuntBijgewerkt;
        private System.Windows.Forms.CheckBox MarkeerVormpuntBijgewerkt;
        private System.Windows.Forms.Button KleurLijnNietMonotoon;
        private System.Windows.Forms.CheckBox MarkeerLijnNietMonotoon;
        private System.Windows.Forms.CheckBox OpslaanLijnNietMonotoon;
        private System.Windows.Forms.CheckBox SaveEdits;
        private System.Windows.Forms.CheckBox LogVormpunten;
        private System.Windows.Forms.GroupBox grpVW_HECTOMETERRAAI;
        private System.Windows.Forms.TextBox raai_selectie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button KleurRaaiMetOngeldigeHmwaarde;
        private System.Windows.Forms.CheckBox MarkeerRaaiMetOngeldigeHmwaarde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox raai_afstand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mshape_maxafstand;
        private System.Windows.Forms.TextBox mshape_tolerantie;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbKalibreren;
    }
}