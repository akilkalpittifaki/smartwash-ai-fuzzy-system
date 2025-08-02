using System;
using System.Collections.Generic;
using System.Drawing; // Color için eklendi
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Chart için eklendi
using System.Linq; // Linq kullanmak için eklendi

namespace bulanik_mantik_severge7
{
    public partial class Form1 : Form
    {
        private MamdaniFuzzySystem fuzzySystem;

        public Form1()
        {
            InitializeComponent();
            fuzzySystem = new MamdaniFuzzySystem();

            // Olayları bağla
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            this.Load += new System.EventHandler(this.Form1_Load);

            // DataGridView'i ayarla (Form1_Load'a taşıdık)
            // InitializeRuleGrid();
        }

        // Form ilk yüklendiğinde
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView'i kurallar ile doldur
            InitializeRuleGrid();
            
            // Chart'ları kurulum
            InitializeCharts();
            
            // Başlangıç hesaplamasını yap
            CalculateAndDisplay();
        }

        // Chart'ları başlatan metot
        private void InitializeCharts()
        {
            // Dönüş Hızı grafiği
            InitializeChart(chartDonusHizi, "Dönüş Hızı", Color.Blue);
            
            // Süre grafiği
            InitializeChart(chartSure, "Süre", Color.Green);
            
            // Deterjan grafiği
            InitializeChart(chartDeterjan, "Deterjan Miktarı", Color.Red);
        }

        // Bir chart'ı konfigüre eden metot
        private void InitializeChart(Chart chart, string title, Color color)
        {
            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.ChartAreas.Clear();
            var chartArea = new ChartArea("Main");
            chartArea.AxisX.Title = "Değer";
            chartArea.AxisY.Title = "Üyelik Derecesi";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1;
            chart.ChartAreas.Add(chartArea);

            chart.Series.Clear();
            // Ana Seri - Çıkış Fonksiyonu
            var series = new Series("Output")
            {
                ChartType = SeriesChartType.Line,
                Color = color,
                BorderWidth = 2
            };
            chart.Series.Add(series);

            // Centroid Seri - Dikey çizgi
            var centroidSeries = new Series("Centroid")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Black,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Dash
            };
            chart.Series.Add(centroidSeries);
        }

        // Kural tablosu DataGridView'ini başlatan metot
        private void InitializeRuleGrid()
        {
            dataGridViewRules.Rows.Clear(); // Önce temizle
            dataGridViewRules.Columns.Clear(); // Önce temizle

            // Kolonları oluştur
            dataGridViewRules.Columns.Add("No", "No");
            dataGridViewRules.Columns.Add("IfHassaslik", "IF Hassaslık =");
            dataGridViewRules.Columns.Add("AndMiktar", "AND Miktar =");
            dataGridViewRules.Columns.Add("AndKirlilik", "AND Kirlilik =");
            dataGridViewRules.Columns.Add("ThenHiz", "THEN Hız =");
            dataGridViewRules.Columns.Add("ThenSure", "THEN Süre =");
            dataGridViewRules.Columns.Add("ThenDeterjan", "THEN Deterjan =");

            // Kolon genişliklerini ayarla (isteğe bağlı)
            dataGridViewRules.Columns["No"].Width = 30;
            dataGridViewRules.Columns["IfHassaslik"].Width = 70;
            dataGridViewRules.Columns["AndMiktar"].Width = 70;
            dataGridViewRules.Columns["AndKirlilik"].Width = 70;
            dataGridViewRules.Columns["ThenHiz"].Width = 70;
            dataGridViewRules.Columns["ThenSure"].Width = 70;
            dataGridViewRules.Columns["ThenDeterjan"].Width = 80; // Biraz daha geniş

            // Kuralları fuzzySystem'den alıp tabloya ekle
            int ruleNumber = 1;
            foreach (var rule in fuzzySystem.Rules) // fuzzySystem.Rules public olmalı
            {
                dataGridViewRules.Rows.Add(
                    ruleNumber++,
                    rule.Antecedents.GetValueOrDefault("Hassaslık", ""),
                    rule.Antecedents.GetValueOrDefault("Miktar", ""),
                    rule.Antecedents.GetValueOrDefault("Kirlilik", ""),
                    rule.Consequents.GetValueOrDefault("Dönüş Hızı", ""),
                    rule.Consequents.GetValueOrDefault("Süre", ""),
                    rule.Consequents.GetValueOrDefault("Deterjan Miktarı", "")
                );
            }
            // Seçimi kaldır
            dataGridViewRules.ClearSelection();
        }


        // Hesapla butonuna tıklandığında
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            CalculateAndDisplay(); // Hesapla ve göster
        }

        // Hesaplama ve gösterme işlevi
        private void CalculateAndDisplay()
        {
            try
            {
                // Girişleri al
                double hassaslik = (double)numericHassaslik.Value;
                double miktar = (double)numericMiktar.Value;
                double kirlilik = (double)numericKirlilik.Value;

                // --- YENİ: Detaylı hesaplama yap ---
                FuzzyResult result = fuzzySystem.CalculateDetailed(hassaslik, miktar, kirlilik);

                // --- Ağırlıklı Ortalama Sonuçları ---
                // Sonuçları göster (Net Çıktılar - Ağırlıklı Ortalama)
                txtDonusHizi.Text = result.CrispOutputs[FuzzyLogicDefinitions.SpinSpeed.Name].ToString("F2");
                txtSure.Text = result.CrispOutputs[FuzzyLogicDefinitions.Duration.Name].ToString("F2");
                txtDeterjan.Text = result.CrispOutputs[FuzzyLogicDefinitions.Detergent.Name].ToString("F2");

                // --- YENİ: Centroid Sonuçları ---
                // Centroid yöntemi ile hesaplanan sonuçları göster
                txtCentroidDonusHizi.Text = result.CentroidOutputs[FuzzyLogicDefinitions.SpinSpeed.Name].ToString("F2");
                txtCentroidSure.Text = result.CentroidOutputs[FuzzyLogicDefinitions.Duration.Name].ToString("F2");
                txtCentroidDeterjan.Text = result.CentroidOutputs[FuzzyLogicDefinitions.Detergent.Name].ToString("F2");

                // --- YENİ: Grafikleri Güncelle ---
                UpdateChart(chartDonusHizi, 
                    result.OutputMembershipValues[FuzzyLogicDefinitions.SpinSpeed.Name]);
                UpdateChart(chartSure, 
                    result.OutputMembershipValues[FuzzyLogicDefinitions.Duration.Name]);
                UpdateChart(chartDeterjan, 
                    result.OutputMembershipValues[FuzzyLogicDefinitions.Detergent.Name]);

                // --- Aktif Kural Ateşlemelerini ListBox'ta göster ---
                listBoxFiringStrengths.Items.Clear(); // Önceki listeyi temizle
                for (int i = 0; i < result.RuleFiringStrengths.Count; i++)
                {
                    double strength = result.RuleFiringStrengths[i];
                    if (strength > 0) // Sadece ateşlenenleri göster
                    {
                        listBoxFiringStrengths.Items.Add($"Kural {i + 1}: {strength:F4}"); // 4 ondalıkla göster
                    }
                }

                // --- Kural Tablosunda Aktif Kuralları Vurgula ---
                // Önce tüm vurguları kaldır
                foreach (DataGridViewRow row in dataGridViewRules.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Veya sistemin varsayılan rengi
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                // Sonra aktif olanları vurgula
                for (int i = 0; i < result.RuleFiringStrengths.Count; i++)
                {
                    if (result.RuleFiringStrengths[i] > 0)
                    {
                        // Vurgulama rengini seçebilirsin
                        dataGridViewRules.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                        // dataGridViewRules.Rows[i].Selected = true; // Veya seçili yapabilirsin
                    }
                }
                dataGridViewRules.ClearSelection(); // Seçimi tekrar kaldır ki sadece renk görünsün
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Çıkış fonksiyonu grafiğini güncelle
        private void UpdateChart(Chart chart, OutputMembershipData data)
        {
            // Ana seriyi (bulanık çıkış fonksiyonu) temizle ve yeni verileri ekle
            chart.Series["Output"].Points.Clear();
            for (int i = 0; i < data.XValues.Length; i++)
            {
                chart.Series["Output"].Points.AddXY(data.XValues[i], data.YValues[i]);
            }

            // Centroid çizgisini güncelle
            chart.Series["Centroid"].Points.Clear();
            chart.Series["Centroid"].Points.AddXY(data.CentroidPoint, 0);
            chart.Series["Centroid"].Points.AddXY(data.CentroidPoint, 1);
            
            // Eksenleri otomatik ayarla
            chart.ChartAreas[0].RecalculateAxesScale();
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 1;
        }
    }
}