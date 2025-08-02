// Form1.Designer.cs

namespace bulanik_mantik_severge7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // --- Mevcut Kontroller ---
            this.labelHassaslik = new System.Windows.Forms.Label();
            this.numericHassaslik = new System.Windows.Forms.NumericUpDown();
            this.labelMiktar = new System.Windows.Forms.Label();
            this.numericMiktar = new System.Windows.Forms.NumericUpDown();
            this.labelKirlilik = new System.Windows.Forms.Label();
            this.numericKirlilik = new System.Windows.Forms.NumericUpDown();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.labelDonusHizi = new System.Windows.Forms.Label();
            this.txtDonusHizi = new System.Windows.Forms.TextBox();
            this.labelSure = new System.Windows.Forms.Label();
            this.txtSure = new System.Windows.Forms.TextBox();
            this.labelDeterjan = new System.Windows.Forms.Label();
            this.txtDeterjan = new System.Windows.Forms.TextBox();
            this.groupBoxGiris = new System.Windows.Forms.GroupBox();
            this.groupBoxCikis = new System.Windows.Forms.GroupBox();
            // --- YENİ Kontroller ---
            this.dataGridViewRules = new System.Windows.Forms.DataGridView();
            this.listBoxFiringStrengths = new System.Windows.Forms.ListBox();
            this.labelRules = new System.Windows.Forms.Label();
            this.labelFiringStrengths = new System.Windows.Forms.Label();
            // --- YENİ Chart Kontrolleri ---
            this.chartDonusHizi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSure = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDeterjan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHiz = new System.Windows.Forms.TabPage();
            this.tabPageSure = new System.Windows.Forms.TabPage();
            this.tabPageDeterjan = new System.Windows.Forms.TabPage();
            this.labelCentroidResults = new System.Windows.Forms.Label();
            this.txtCentroidDonusHizi = new System.Windows.Forms.TextBox();
            this.txtCentroidSure = new System.Windows.Forms.TextBox();
            this.txtCentroidDeterjan = new System.Windows.Forms.TextBox();
            this.labelCentroidDonusHizi = new System.Windows.Forms.Label();
            this.labelCentroidSure = new System.Windows.Forms.Label();
            this.labelCentroidDeterjan = new System.Windows.Forms.Label();
            this.groupBoxCentroid = new System.Windows.Forms.GroupBox();
            // --- Başlatmalar ---
            ((System.ComponentModel.ISupportInitialize)(this.numericHassaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKirlilik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).BeginInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartDonusHizi)).BeginInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartSure)).BeginInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartDeterjan)).BeginInit(); // YENİ
            this.tabControl.SuspendLayout();
            this.tabPageHiz.SuspendLayout();
            this.tabPageSure.SuspendLayout();
            this.tabPageDeterjan.SuspendLayout();
            this.groupBoxGiris.SuspendLayout();
            this.groupBoxCikis.SuspendLayout();
            this.groupBoxCentroid.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxGiris
            //
            this.groupBoxGiris.Controls.Add(this.numericKirlilik);
            this.groupBoxGiris.Controls.Add(this.labelKirlilik);
            this.groupBoxGiris.Controls.Add(this.numericMiktar);
            this.groupBoxGiris.Controls.Add(this.labelMiktar);
            this.groupBoxGiris.Controls.Add(this.numericHassaslik);
            this.groupBoxGiris.Controls.Add(this.labelHassaslik);
            this.groupBoxGiris.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGiris.Name = "groupBoxGiris";
            this.groupBoxGiris.Size = new System.Drawing.Size(260, 120);
            this.groupBoxGiris.TabIndex = 0;
            this.groupBoxGiris.TabStop = false;
            this.groupBoxGiris.Text = "Giriş Değerleri";
            //
            // labelHassaslik
            //
            this.labelHassaslik.AutoSize = true;
            this.labelHassaslik.Location = new System.Drawing.Point(15, 28);
            this.labelHassaslik.Name = "labelHassaslik";
            this.labelHassaslik.Size = new System.Drawing.Size(99, 15);
            this.labelHassaslik.TabIndex = 0;
            this.labelHassaslik.Text = "Hassaslık (0-10):";
            //
            // numericHassaslik
            //
            this.numericHassaslik.DecimalPlaces = 1;
            this.numericHassaslik.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numericHassaslik.Location = new System.Drawing.Point(120, 26);
            this.numericHassaslik.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericHassaslik.Name = "numericHassaslik";
            this.numericHassaslik.Size = new System.Drawing.Size(120, 23);
            this.numericHassaslik.TabIndex = 1;
            this.numericHassaslik.Value = new decimal(new int[] { 5, 0, 0, 0 });
            //
            // labelMiktar
            //
            this.labelMiktar.AutoSize = true;
            this.labelMiktar.Location = new System.Drawing.Point(15, 57);
            this.labelMiktar.Name = "labelMiktar";
            this.labelMiktar.Size = new System.Drawing.Size(79, 15);
            this.labelMiktar.TabIndex = 2;
            this.labelMiktar.Text = "Miktar (0-10):";
            //
            // numericMiktar
            //
            this.numericMiktar.DecimalPlaces = 1;
            this.numericMiktar.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numericMiktar.Location = new System.Drawing.Point(120, 55);
            this.numericMiktar.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericMiktar.Name = "numericMiktar";
            this.numericMiktar.Size = new System.Drawing.Size(120, 23);
            this.numericMiktar.TabIndex = 3;
            this.numericMiktar.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // labelKirlilik
            //
            this.labelKirlilik.AutoSize = true;
            this.labelKirlilik.Location = new System.Drawing.Point(15, 86);
            this.labelKirlilik.Name = "labelKirlilik";
            this.labelKirlilik.Size = new System.Drawing.Size(77, 15);
            this.labelKirlilik.TabIndex = 4;
            this.labelKirlilik.Text = "Kirlilik (0-10):";
            //
            // numericKirlilik
            //
            this.numericKirlilik.DecimalPlaces = 1;
            this.numericKirlilik.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numericKirlilik.Location = new System.Drawing.Point(120, 84);
            this.numericKirlilik.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericKirlilik.Name = "numericKirlilik";
            this.numericKirlilik.Size = new System.Drawing.Size(120, 23);
            this.numericKirlilik.TabIndex = 5;
            this.numericKirlilik.Value = new decimal(new int[] { 39, 0, 0, 65536 }); // 3.9
            //
            // btnHesapla
            //
            this.btnHesapla.Location = new System.Drawing.Point(102, 138);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(75, 23);
            this.btnHesapla.TabIndex = 1;
            this.btnHesapla.Text = "Hesapla";
            this.btnHesapla.UseVisualStyleBackColor = true;
            // Click eventi Form1.cs içinde bağlanacak
            //
            // groupBoxCikis
            //
            this.groupBoxCikis.Controls.Add(this.txtDeterjan);
            this.groupBoxCikis.Controls.Add(this.labelDeterjan);
            this.groupBoxCikis.Controls.Add(this.txtSure);
            this.groupBoxCikis.Controls.Add(this.labelSure);
            this.groupBoxCikis.Controls.Add(this.txtDonusHizi);
            this.groupBoxCikis.Controls.Add(this.labelDonusHizi);
            this.groupBoxCikis.Location = new System.Drawing.Point(12, 167);
            this.groupBoxCikis.Name = "groupBoxCikis";
            this.groupBoxCikis.Size = new System.Drawing.Size(260, 110);
            this.groupBoxCikis.TabIndex = 2;
            this.groupBoxCikis.TabStop = false;
            this.groupBoxCikis.Text = "Çıkış Değerleri";
            //
            // labelDonusHizi
            //
            this.labelDonusHizi.AutoSize = true;
            this.labelDonusHizi.Location = new System.Drawing.Point(15, 28);
            this.labelDonusHizi.Name = "labelDonusHizi";
            this.labelDonusHizi.Size = new System.Drawing.Size(69, 15);
            this.labelDonusHizi.TabIndex = 0;
            this.labelDonusHizi.Text = "Dönüş Hızı:";
            //
            // txtDonusHizi
            //
            this.txtDonusHizi.Location = new System.Drawing.Point(120, 25);
            this.txtDonusHizi.Name = "txtDonusHizi";
            this.txtDonusHizi.ReadOnly = true;
            this.txtDonusHizi.Size = new System.Drawing.Size(120, 23);
            this.txtDonusHizi.TabIndex = 1;
            //
            // labelSure
            //
            this.labelSure.AutoSize = true;
            this.labelSure.Location = new System.Drawing.Point(15, 57);
            this.labelSure.Name = "labelSure";
            this.labelSure.Size = new System.Drawing.Size(34, 15);
            this.labelSure.TabIndex = 2;
            this.labelSure.Text = "Süre:";
            //
            // txtSure
            //
            this.txtSure.Location = new System.Drawing.Point(120, 54);
            this.txtSure.Name = "txtSure";
            this.txtSure.ReadOnly = true;
            this.txtSure.Size = new System.Drawing.Size(120, 23);
            this.txtSure.TabIndex = 3;
            //
            // labelDeterjan
            //
            this.labelDeterjan.AutoSize = true;
            this.labelDeterjan.Location = new System.Drawing.Point(15, 86);
            this.labelDeterjan.Name = "labelDeterjan";
            this.labelDeterjan.Size = new System.Drawing.Size(97, 15);
            this.labelDeterjan.TabIndex = 4;
            this.labelDeterjan.Text = "Deterjan Miktarı:";
            //
            // txtDeterjan
            //
            this.txtDeterjan.Location = new System.Drawing.Point(120, 83);
            this.txtDeterjan.Name = "txtDeterjan";
            this.txtDeterjan.ReadOnly = true;
            this.txtDeterjan.Size = new System.Drawing.Size(120, 23);
            this.txtDeterjan.TabIndex = 5;
            //
            // groupBoxCentroid
            //
            this.groupBoxCentroid.Controls.Add(this.txtCentroidDeterjan);
            this.groupBoxCentroid.Controls.Add(this.labelCentroidDeterjan);
            this.groupBoxCentroid.Controls.Add(this.txtCentroidSure);
            this.groupBoxCentroid.Controls.Add(this.labelCentroidSure);
            this.groupBoxCentroid.Controls.Add(this.txtCentroidDonusHizi);
            this.groupBoxCentroid.Controls.Add(this.labelCentroidDonusHizi);
            this.groupBoxCentroid.Location = new System.Drawing.Point(12, 388);
            this.groupBoxCentroid.Name = "groupBoxCentroid";
            this.groupBoxCentroid.Size = new System.Drawing.Size(260, 110);
            this.groupBoxCentroid.TabIndex = 7;
            this.groupBoxCentroid.TabStop = false;
            this.groupBoxCentroid.Text = "Centroid Sonuçları";
            //
            // labelCentroidDonusHizi
            //
            this.labelCentroidDonusHizi.AutoSize = true;
            this.labelCentroidDonusHizi.Location = new System.Drawing.Point(15, 28);
            this.labelCentroidDonusHizi.Name = "labelCentroidDonusHizi";
            this.labelCentroidDonusHizi.Size = new System.Drawing.Size(69, 15);
            this.labelCentroidDonusHizi.TabIndex = 0;
            this.labelCentroidDonusHizi.Text = "Dönüş Hızı:";
            //
            // txtCentroidDonusHizi
            //
            this.txtCentroidDonusHizi.Location = new System.Drawing.Point(120, 25);
            this.txtCentroidDonusHizi.Name = "txtCentroidDonusHizi";
            this.txtCentroidDonusHizi.ReadOnly = true;
            this.txtCentroidDonusHizi.Size = new System.Drawing.Size(120, 23);
            this.txtCentroidDonusHizi.TabIndex = 1;
            //
            // labelCentroidSure
            //
            this.labelCentroidSure.AutoSize = true;
            this.labelCentroidSure.Location = new System.Drawing.Point(15, 57);
            this.labelCentroidSure.Name = "labelCentroidSure";
            this.labelCentroidSure.Size = new System.Drawing.Size(34, 15);
            this.labelCentroidSure.TabIndex = 2;
            this.labelCentroidSure.Text = "Süre:";
            //
            // txtCentroidSure
            //
            this.txtCentroidSure.Location = new System.Drawing.Point(120, 54);
            this.txtCentroidSure.Name = "txtCentroidSure";
            this.txtCentroidSure.ReadOnly = true;
            this.txtCentroidSure.Size = new System.Drawing.Size(120, 23);
            this.txtCentroidSure.TabIndex = 3;
            //
            // labelCentroidDeterjan
            //
            this.labelCentroidDeterjan.AutoSize = true;
            this.labelCentroidDeterjan.Location = new System.Drawing.Point(15, 86);
            this.labelCentroidDeterjan.Name = "labelCentroidDeterjan";
            this.labelCentroidDeterjan.Size = new System.Drawing.Size(97, 15);
            this.labelCentroidDeterjan.TabIndex = 4;
            this.labelCentroidDeterjan.Text = "Deterjan Miktarı:";
            //
            // txtCentroidDeterjan
            //
            this.txtCentroidDeterjan.Location = new System.Drawing.Point(120, 83);
            this.txtCentroidDeterjan.Name = "txtCentroidDeterjan";
            this.txtCentroidDeterjan.ReadOnly = true;
            this.txtCentroidDeterjan.Size = new System.Drawing.Size(120, 23);
            this.txtCentroidDeterjan.TabIndex = 5;
            //
            // labelRules (YENİ)
            //
            this.labelRules.AutoSize = true;
            this.labelRules.Location = new System.Drawing.Point(290, 12);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(80, 15);
            this.labelRules.TabIndex = 3;
            this.labelRules.Text = "Kural Tablosu:";
            //
            // dataGridViewRules (YENİ)
            //
            this.dataGridViewRules.AllowUserToAddRows = false;
            this.dataGridViewRules.AllowUserToDeleteRows = false;
            this.dataGridViewRules.AllowUserToResizeRows = false;
            this.dataGridViewRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRules.Location = new System.Drawing.Point(290, 30);
            this.dataGridViewRules.Name = "dataGridViewRules";
            this.dataGridViewRules.ReadOnly = true;
            this.dataGridViewRules.RowHeadersVisible = false;
            this.dataGridViewRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRules.Size = new System.Drawing.Size(480, 247); // Boyutu ihtiyaca göre ayarla
            this.dataGridViewRules.TabIndex = 4;
            //
            // labelFiringStrengths (YENİ)
            //
            this.labelFiringStrengths.AutoSize = true;
            this.labelFiringStrengths.Location = new System.Drawing.Point(12, 285); // Giriş/Çıkış'ın altına
            this.labelFiringStrengths.Name = "labelFiringStrengths";
            this.labelFiringStrengths.Size = new System.Drawing.Size(136, 15);
            this.labelFiringStrengths.TabIndex = 5;
            this.labelFiringStrengths.Text = "Aktif Kural Ateşlemeleri:";
            //
            // listBoxFiringStrengths (YENİ)
            //
            this.listBoxFiringStrengths.FormattingEnabled = true;
            this.listBoxFiringStrengths.ItemHeight = 15;
            this.listBoxFiringStrengths.Location = new System.Drawing.Point(12, 303); // Label'ın altına
            this.listBoxFiringStrengths.Name = "listBoxFiringStrengths";
            this.listBoxFiringStrengths.Size = new System.Drawing.Size(260, 79); // Boyutu ayarla
            this.listBoxFiringStrengths.TabIndex = 6;
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabPageHiz);
            this.tabControl.Controls.Add(this.tabPageSure);
            this.tabControl.Controls.Add(this.tabPageDeterjan);
            this.tabControl.Location = new System.Drawing.Point(290, 283);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(480, 300);
            this.tabControl.TabIndex = 8;
            //
            // tabPageHiz
            //
            this.tabPageHiz.Controls.Add(this.chartDonusHizi);
            this.tabPageHiz.Location = new System.Drawing.Point(4, 24);
            this.tabPageHiz.Name = "tabPageHiz";
            this.tabPageHiz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHiz.Size = new System.Drawing.Size(472, 272);
            this.tabPageHiz.TabIndex = 0;
            this.tabPageHiz.Text = "Dönüş Hızı";
            this.tabPageHiz.UseVisualStyleBackColor = true;
            //
            // tabPageSure
            //
            this.tabPageSure.Controls.Add(this.chartSure);
            this.tabPageSure.Location = new System.Drawing.Point(4, 24);
            this.tabPageSure.Name = "tabPageSure";
            this.tabPageSure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSure.Size = new System.Drawing.Size(472, 272);
            this.tabPageSure.TabIndex = 1;
            this.tabPageSure.Text = "Süre";
            this.tabPageSure.UseVisualStyleBackColor = true;
            //
            // tabPageDeterjan
            //
            this.tabPageDeterjan.Controls.Add(this.chartDeterjan);
            this.tabPageDeterjan.Location = new System.Drawing.Point(4, 24);
            this.tabPageDeterjan.Name = "tabPageDeterjan";
            this.tabPageDeterjan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeterjan.Size = new System.Drawing.Size(472, 272);
            this.tabPageDeterjan.TabIndex = 2;
            this.tabPageDeterjan.Text = "Deterjan";
            this.tabPageDeterjan.UseVisualStyleBackColor = true;
            //
            // chartDonusHizi
            //
            this.chartDonusHizi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDonusHizi.Location = new System.Drawing.Point(3, 3);
            this.chartDonusHizi.Name = "chartDonusHizi";
            this.chartDonusHizi.Size = new System.Drawing.Size(466, 266);
            this.chartDonusHizi.TabIndex = 0;
            this.chartDonusHizi.Text = "Dönüş Hızı";
            //
            // chartSure
            //
            this.chartSure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSure.Location = new System.Drawing.Point(3, 3);
            this.chartSure.Name = "chartSure";
            this.chartSure.Size = new System.Drawing.Size(466, 266);
            this.chartSure.TabIndex = 0;
            this.chartSure.Text = "Süre";
            //
            // chartDeterjan
            //
            this.chartDeterjan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDeterjan.Location = new System.Drawing.Point(3, 3);
            this.chartDeterjan.Name = "chartDeterjan";
            this.chartDeterjan.Size = new System.Drawing.Size(466, 266);
            this.chartDeterjan.TabIndex = 0;
            this.chartDeterjan.Text = "Deterjan";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Form boyutunu genişlet
            this.ClientSize = new System.Drawing.Size(784, 600); // Yeni boyut - daha yüksek
            // YENİ Kontrolleri ekle
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBoxCentroid);
            this.Controls.Add(this.listBoxFiringStrengths);
            this.Controls.Add(this.labelFiringStrengths);
            this.Controls.Add(this.labelRules);
            this.Controls.Add(this.dataGridViewRules);
            // Mevcut Kontroller
            this.Controls.Add(this.groupBoxCikis);
            this.Controls.Add(this.btnHesapla);
            this.Controls.Add(this.groupBoxGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulanık Çamaşır Makinesi";
            // Kontrol bitirmeleri
            ((System.ComponentModel.ISupportInitialize)(this.numericHassaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKirlilik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).EndInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartDonusHizi)).EndInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartSure)).EndInit(); // YENİ
            ((System.ComponentModel.ISupportInitialize)(this.chartDeterjan)).EndInit(); // YENİ
            this.tabControl.ResumeLayout(false);
            this.tabPageHiz.ResumeLayout(false);
            this.tabPageSure.ResumeLayout(false);
            this.tabPageDeterjan.ResumeLayout(false);
            this.groupBoxGiris.ResumeLayout(false);
            this.groupBoxGiris.PerformLayout();
            this.groupBoxCikis.ResumeLayout(false);
            this.groupBoxCikis.PerformLayout();
            this.groupBoxCentroid.ResumeLayout(false);
            this.groupBoxCentroid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout(); // YENİ (Eklenen labellar için)

        }

        #endregion

        // Mevcut Kontrol değişken tanımlamaları
        private System.Windows.Forms.Label labelHassaslik;
        private System.Windows.Forms.NumericUpDown numericHassaslik;
        private System.Windows.Forms.Label labelMiktar;
        private System.Windows.Forms.NumericUpDown numericMiktar;
        private System.Windows.Forms.Label labelKirlilik;
        private System.Windows.Forms.NumericUpDown numericKirlilik;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Label labelDonusHizi;
        private System.Windows.Forms.TextBox txtDonusHizi;
        private System.Windows.Forms.Label labelSure;
        private System.Windows.Forms.TextBox txtSure;
        private System.Windows.Forms.Label labelDeterjan;
        private System.Windows.Forms.TextBox txtDeterjan;
        private System.Windows.Forms.GroupBox groupBoxGiris;
        private System.Windows.Forms.GroupBox groupBoxCikis;
        // YENİ Kontrol değişken tanımlamaları
        private System.Windows.Forms.DataGridView dataGridViewRules;
        private System.Windows.Forms.ListBox listBoxFiringStrengths;
        private System.Windows.Forms.Label labelRules;
        private System.Windows.Forms.Label labelFiringStrengths;
        // YENİ Chart kontrolleri değişken tanımlamaları
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDonusHizi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSure;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDeterjan;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHiz;
        private System.Windows.Forms.TabPage tabPageSure;
        private System.Windows.Forms.TabPage tabPageDeterjan;
        private System.Windows.Forms.GroupBox groupBoxCentroid;
        private System.Windows.Forms.TextBox txtCentroidDeterjan;
        private System.Windows.Forms.Label labelCentroidDeterjan;
        private System.Windows.Forms.TextBox txtCentroidSure;
        private System.Windows.Forms.Label labelCentroidSure;
        private System.Windows.Forms.TextBox txtCentroidDonusHizi;
        private System.Windows.Forms.Label labelCentroidDonusHizi;
        private System.Windows.Forms.Label labelCentroidResults;
    }
}