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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fcLRS_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lrs_selectie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mshape_tolerantie = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mshape_maxafstand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.raai_afstand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mshape_sleutel2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mshape_sleutel1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mshape_eindkm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mshape_beginkm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KleurLijnNietMonotoon = new System.Windows.Forms.Button();
            this.MarkeerLijnNietMonotoon = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntNietBijgewerkt = new System.Windows.Forms.Button();
            this.MarkeerVormpuntNietBijgewerkt = new System.Windows.Forms.CheckBox();
            this.KleurVormpuntBijgewerkt = new System.Windows.Forms.Button();
            this.MarkeerVormpuntBijgewerkt = new System.Windows.Forms.CheckBox();
            this.TolerantieVormpuntBuitenInterval = new System.Windows.Forms.TextBox();
            this.KleurVormpuntBuitenInterval = new System.Windows.Forms.Button();
            this.MarkeerVormpuntBuitenInterval = new System.Windows.Forms.CheckBox();
            this.SaveEdits = new System.Windows.Forms.CheckBox();
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
            this.OpslaanLijnNietMonotoon = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Location = new System.Drawing.Point(636, 469);
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
            this.cmdAnnuleren.Location = new System.Drawing.Point(555, 469);
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
            this.tabControl1.Size = new System.Drawing.Size(707, 451);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Instellingen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.fcLRS_name);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lrs_selectie);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(9, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 85);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LRS instellingen";
            // 
            // fcLRS_name
            // 
            this.fcLRS_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fcLRS_name.Location = new System.Drawing.Point(275, 23);
            this.fcLRS_name.Name = "fcLRS_name";
            this.fcLRS_name.Size = new System.Drawing.Size(399, 20);
            this.fcLRS_name.TabIndex = 11;
            this.fcLRS_name.Tag = "";
            this.fcLRS_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "LRS";
            // 
            // lrs_selectie
            // 
            this.lrs_selectie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lrs_selectie.Location = new System.Drawing.Point(275, 53);
            this.lrs_selectie.Name = "lrs_selectie";
            this.lrs_selectie.Size = new System.Drawing.Size(399, 20);
            this.lrs_selectie.TabIndex = 9;
            this.lrs_selectie.Tag = "";
            this.lrs_selectie.TextChanged += new System.EventHandler(this.lrs_selectie_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "LRS selectie";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.mshape_tolerantie);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.mshape_maxafstand);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.raai_afstand);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(9, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 125);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zoekinstellingen";
            // 
            // mshape_tolerantie
            // 
            this.mshape_tolerantie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_tolerantie.Location = new System.Drawing.Point(284, 72);
            this.mshape_tolerantie.Name = "mshape_tolerantie";
            this.mshape_tolerantie.Size = new System.Drawing.Size(390, 20);
            this.mshape_tolerantie.TabIndex = 9;
            this.mshape_tolerantie.Tag = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tolerantie kilometer interval";
            // 
            // mshape_maxafstand
            // 
            this.mshape_maxafstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_maxafstand.Location = new System.Drawing.Point(284, 46);
            this.mshape_maxafstand.Name = "mshape_maxafstand";
            this.mshape_maxafstand.Size = new System.Drawing.Size(390, 20);
            this.mshape_maxafstand.TabIndex = 7;
            this.mshape_maxafstand.Tag = "mshape_maxafstand";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Maximale zoekafstand spoorhartlijn";
            // 
            // raai_afstand
            // 
            this.raai_afstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raai_afstand.Location = new System.Drawing.Point(284, 20);
            this.raai_afstand.Name = "raai_afstand";
            this.raai_afstand.Size = new System.Drawing.Size(390, 20);
            this.raai_afstand.TabIndex = 5;
            this.raai_afstand.Tag = "raai_afstand";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Maximale zoekafstand raaien";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mshape_sleutel2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mshape_sleutel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mshape_eindkm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mshape_beginkm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 132);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "M-shape instellingen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Geocode veld:";
            // 
            // mshape_sleutel2
            // 
            this.mshape_sleutel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_sleutel2.Location = new System.Drawing.Point(284, 100);
            this.mshape_sleutel2.Name = "mshape_sleutel2";
            this.mshape_sleutel2.Size = new System.Drawing.Size(390, 20);
            this.mshape_sleutel2.TabIndex = 7;
            this.mshape_sleutel2.Tag = "mshape_sleutel2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Geocode veld 2 (optioneel)";
            // 
            // mshape_sleutel1
            // 
            this.mshape_sleutel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_sleutel1.Location = new System.Drawing.Point(284, 72);
            this.mshape_sleutel1.Name = "mshape_sleutel1";
            this.mshape_sleutel1.Size = new System.Drawing.Size(390, 20);
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
            // mshape_eindkm
            // 
            this.mshape_eindkm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_eindkm.Location = new System.Drawing.Point(284, 44);
            this.mshape_eindkm.Name = "mshape_eindkm";
            this.mshape_eindkm.Size = new System.Drawing.Size(390, 20);
            this.mshape_eindkm.TabIndex = 3;
            this.mshape_eindkm.Tag = "mshape_eindkm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Eindkm veld:";
            // 
            // mshape_beginkm
            // 
            this.mshape_beginkm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mshape_beginkm.Location = new System.Drawing.Point(284, 18);
            this.mshape_beginkm.Name = "mshape_beginkm";
            this.mshape_beginkm.Size = new System.Drawing.Size(390, 20);
            this.mshape_beginkm.TabIndex = 1;
            this.mshape_beginkm.Tag = "mshape_beginkm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginkm veld:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Markeringen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
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
            this.groupBox3.Controls.Add(this.SaveEdits);
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
            this.groupBox3.Size = new System.Drawing.Size(693, 419);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // KleurLijnNietMonotoon
            // 
            this.KleurLijnNietMonotoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurLijnNietMonotoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurLijnNietMonotoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurLijnNietMonotoon.Location = new System.Drawing.Point(653, 85);
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
            this.KleurVormpuntNietBijgewerkt.Location = new System.Drawing.Point(653, 52);
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
            this.KleurVormpuntBijgewerkt.Location = new System.Drawing.Point(653, 19);
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
            this.TolerantieVormpuntBuitenInterval.Location = new System.Drawing.Point(581, 258);
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
            this.KleurVormpuntBuitenInterval.Location = new System.Drawing.Point(653, 257);
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
            // SaveEdits
            // 
            this.SaveEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveEdits.AutoSize = true;
            this.SaveEdits.Location = new System.Drawing.Point(6, 396);
            this.SaveEdits.Name = "SaveEdits";
            this.SaveEdits.Size = new System.Drawing.Size(89, 17);
            this.SaveEdits.TabIndex = 10;
            this.SaveEdits.Text = "Edits opslaan";
            this.SaveEdits.UseVisualStyleBackColor = true;
            // 
            // KleurVormpuntMetAfwijking
            // 
            this.KleurVormpuntMetAfwijking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KleurVormpuntMetAfwijking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KleurVormpuntMetAfwijking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KleurVormpuntMetAfwijking.Location = new System.Drawing.Point(653, 223);
            this.KleurVormpuntMetAfwijking.Name = "KleurVormpuntMetAfwijking";
            this.KleurVormpuntMetAfwijking.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntMetAfwijking.TabIndex = 9;
            this.KleurVormpuntMetAfwijking.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurVormpuntMetAfwijking.UseVisualStyleBackColor = false;
            // 
            // VerschilVormpuntMetAfwijking
            // 
            this.VerschilVormpuntMetAfwijking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VerschilVormpuntMetAfwijking.Location = new System.Drawing.Point(581, 225);
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
            this.KleurLijnBuitenZoekAfstand.Location = new System.Drawing.Point(653, 188);
            this.KleurLijnBuitenZoekAfstand.Name = "KleurLijnBuitenZoekAfstand";
            this.KleurLijnBuitenZoekAfstand.Size = new System.Drawing.Size(27, 23);
            this.KleurLijnBuitenZoekAfstand.TabIndex = 6;
            this.KleurLijnBuitenZoekAfstand.Tag = "KleurLijnBuitenZoekAfstand";
            this.KleurLijnBuitenZoekAfstand.UseVisualStyleBackColor = false;
            // 
            // AfstandLijnBuitenZoekAfstand
            // 
            this.AfstandLijnBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AfstandLijnBuitenZoekAfstand.Location = new System.Drawing.Point(581, 190);
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
            this.KleurVormpuntBuitenZoekAfstand.Location = new System.Drawing.Point(653, 155);
            this.KleurVormpuntBuitenZoekAfstand.Name = "KleurVormpuntBuitenZoekAfstand";
            this.KleurVormpuntBuitenZoekAfstand.Size = new System.Drawing.Size(27, 23);
            this.KleurVormpuntBuitenZoekAfstand.TabIndex = 3;
            this.KleurVormpuntBuitenZoekAfstand.Tag = "KleurVormpuntBuitenZoekAfstand";
            this.KleurVormpuntBuitenZoekAfstand.UseVisualStyleBackColor = false;
            // 
            // AfstandVormpuntBuitenZoekAfstand
            // 
            this.AfstandVormpuntBuitenZoekAfstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AfstandVormpuntBuitenZoekAfstand.Location = new System.Drawing.Point(581, 157);
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
            this.progressBar.Location = new System.Drawing.Point(9, 469);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(540, 23);
            this.progressBar.TabIndex = 4;
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
            // FormKalibreren
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdAnnuleren;
            this.ClientSize = new System.Drawing.Size(724, 504);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox mshape_maxafstand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox raai_afstand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mshape_sleutel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mshape_sleutel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mshape_eindkm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mshape_beginkm;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.CheckBox SaveEdits;
        private System.Windows.Forms.Button KleurVormpuntBuitenInterval;
        private System.Windows.Forms.CheckBox MarkeerVormpuntBuitenInterval;
        private System.Windows.Forms.TextBox TolerantieVormpuntBuitenInterval;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox lrs_selectie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fcLRS_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mshape_tolerantie;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button KleurVormpuntNietBijgewerkt;
        private System.Windows.Forms.CheckBox MarkeerVormpuntNietBijgewerkt;
        private System.Windows.Forms.Button KleurVormpuntBijgewerkt;
        private System.Windows.Forms.CheckBox MarkeerVormpuntBijgewerkt;
        private System.Windows.Forms.Button KleurLijnNietMonotoon;
        private System.Windows.Forms.CheckBox MarkeerLijnNietMonotoon;
        private System.Windows.Forms.CheckBox OpslaanLijnNietMonotoon;
    }
}