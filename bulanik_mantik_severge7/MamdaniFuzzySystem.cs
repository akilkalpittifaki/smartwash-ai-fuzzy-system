using System;
using System.Collections.Generic;
using System.Linq;

// Namespace'in proje adıyla aynı olduğundan emin ol
namespace bulanik_mantik_severge7
{
    // Hesaplama sonucunu ve ara değerleri (ateşleme güçleri vb.) tutan sınıf
    public class FuzzyResult
    {
        // Sonuç: Net çıkış değerleri (Ağırlıklı Ortalama ile hesaplanmış)
        // Örn: {"Dönüş Hızı": 6.47, "Süre": 68.98, "Deterjan Miktarı": 127.39}
        public Dictionary<string, double> CrispOutputs { get; }

        // Sonuç: Net çıkış değerleri (Centroid yöntemi ile hesaplanmış)
        // Örn: {"Dönüş Hızı": 6.52, "Süre": 69.12, "Deterjan Miktarı": 127.83}
        public Dictionary<string, double> CentroidOutputs { get; }

        // Ara Değer: Her bir kuralın (sırayla 1'den 27'ye) hesaplanan ateşleme gücü
        // Örn: [0, 0, ..., 0.24, 0.45, 0, 0, ...]
        public List<double> RuleFiringStrengths { get; }

        // Ara Değer: Girdi değerlerinin her bir bulanık kümeye üyelik dereceleri
        // Örn: {"Hassaslık": {"Sağlam": 0.0, "Orta": 1.0, "Hassas": 0.0}, ...}
        public Dictionary<string, Dictionary<string, double>> FuzzifiedInputs { get; }

        // Çıkış değişkenlerinin bulanık sonuç eğrileri (grafikte çizilecek)
        // Her bir çıkış değişkeni için x ve y koordinat dizileri
        public Dictionary<string, OutputMembershipData> OutputMembershipValues { get; }

        // Yapıcı metot (constructor)
        public FuzzyResult(
            Dictionary<string, double> crispOutputs, 
            Dictionary<string, double> centroidOutputs,
            List<double> ruleFiringStrengths, 
            Dictionary<string, Dictionary<string, double>> fuzzifiedInputs,
            Dictionary<string, OutputMembershipData> outputMembershipValues)
        {
            CrispOutputs = crispOutputs;
            CentroidOutputs = centroidOutputs;
            RuleFiringStrengths = ruleFiringStrengths;
            FuzzifiedInputs = fuzzifiedInputs;
            OutputMembershipValues = outputMembershipValues;
        }
    }

    // Çıkış değişkeninin grafik için membershiplarını tutan sınıf
    public class OutputMembershipData
    {
        // X ekseni değerleri
        public double[] XValues { get; }
        
        // Y ekseni değerleri (üyelik dereceleri)
        public double[] YValues { get; }
        
        // Maksimum üyelik derecesine sahip nokta (Centroid sonucu)
        public double CentroidPoint { get; }

        public OutputMembershipData(double[] xValues, double[] yValues, double centroidPoint)
        {
            XValues = xValues;
            YValues = yValues;
            CentroidPoint = centroidPoint;
        }
    }


    // Mamdani bulanık çıkarım sistemini yöneten ana sınıf
    public class MamdaniFuzzySystem
    {
        // Kural tabanını (27 kuralı) tutan liste
        private List<FuzzyRule> rules;

        // Sistemin kurallarını public olarak erişilebilir yapalım (tabloyu doldurmak için)
        public IReadOnlyList<FuzzyRule> Rules => rules.AsReadOnly();

        // Grafik için örnekleme nokta sayısı
        private const int SamplingPoints = 200;


        // Yapıcı metot: Kuralları başlatır
        public MamdaniFuzzySystem()
        {
            rules = new List<FuzzyRule>();
            InitializeRules(); // Kuralları PDF'e göre oluşturur
        }

        // PDF'teki 27 kuralı tanımlayan özel metot
        private void InitializeRules()
        {
            // Kural 1
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Küçük")
                .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Kısa").AddConsequent("Deterjan Miktarı", "Çok Az"));
            // Kural 2
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Kısa").AddConsequent("Deterjan Miktarı", "Az"));
            // Kural 3
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Büyük")
                .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Normal-Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 4
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 5
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Normal-Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 6
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Büyük")
               .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 7
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Normal-Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 8
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 9
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Hassas").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Büyük")
               .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 10
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Normal-Kısa").AddConsequent("Deterjan Miktarı", "Az"));
            // Kural 11
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Orta")
                .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 12
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Büyük")
                .AddConsequent("Dönüş Hızı", "Normal-Güçlü").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 13
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Küçük")
                .AddConsequent("Dönüş Hızı", "Normal-Hassas").AddConsequent("Süre", "Normal-Kısa").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 14
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Orta")
                .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 15
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Büyük")
                .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 16
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 17
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Orta")
                .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 18
            rules.Add(new FuzzyRule()
                .AddAntecedent("Hassaslık", "Orta").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Büyük")
                .AddConsequent("Dönüş Hızı", "Hassas").AddConsequent("Süre", "Uzun").AddConsequent("Deterjan Miktarı", "Çok Fazla"));
            // Kural 19
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Az"));
            // Kural 20
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Güçlü").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 21
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Küçük").AddAntecedent("Kirlilik", "Büyük")
               .AddConsequent("Dönüş Hızı", "Güçlü").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 22
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Orta").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Orta"));
            // Kural 23
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Güçlü").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 24
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Orta").AddAntecedent("Kirlilik", "Büyük")
               .AddConsequent("Dönüş Hızı", "Güçlü").AddConsequent("Süre", "Orta").AddConsequent("Deterjan Miktarı", "Çok Fazla"));
            // Kural 25
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Küçük")
               .AddConsequent("Dönüş Hızı", "Normal-Güçlü").AddConsequent("Süre", "Normal-Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 26
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Orta")
               .AddConsequent("Dönüş Hızı", "Normal-Güçlü").AddConsequent("Süre", "Uzun").AddConsequent("Deterjan Miktarı", "Fazla"));
            // Kural 27
            rules.Add(new FuzzyRule()
               .AddAntecedent("Hassaslık", "Sağlam").AddAntecedent("Miktar", "Büyük").AddAntecedent("Kirlilik", "Büyük")
               .AddConsequent("Dönüş Hızı", "Güçlü").AddConsequent("Süre", "Uzun").AddConsequent("Deterjan Miktarı", "Çok Fazla"));
        }


        /// <summary>
        /// Verilen net giriş değerleri için bulanık çıkarım işlemini yapar ve tüm sonuçları döndürür.
        /// </summary>
        /// <param name="sensitivity">Hassaslık değeri (0-10)</param>
        /// <param name="amount">Miktar değeri (0-10)</param>
        /// <param name="dirtiness">Kirlilik değeri (0-10)</param>
        /// <returns>Hesaplanan net çıktılar, kural ateşleme güçleri ve bulanıklaştırılmış girişleri içeren FuzzyResult nesnesi.</returns>
        public FuzzyResult CalculateDetailed(double sensitivity, double amount, double dirtiness)
        {
            // 1. ADIM: Bulanıklaştırma (Fuzzification)
            // Her bir giriş değerinin, ilgili tüm bulanık kümelere (örn: Hassaslık için Sağlam, Orta, Hassas)
            // üyelik derecelerini hesapla.
            var fuzzifiedInputs = new Dictionary<string, Dictionary<string, double>>
            {
                { FuzzyLogicDefinitions.Sensitivity.Name, FuzzyLogicDefinitions.Sensitivity.Fuzzify(sensitivity) },
                { FuzzyLogicDefinitions.Amount.Name, FuzzyLogicDefinitions.Amount.Fuzzify(amount) },
                { FuzzyLogicDefinitions.Dirtiness.Name, FuzzyLogicDefinitions.Dirtiness.Fuzzify(dirtiness) }
            };

            // 2. ADIM: Kural Değerlendirme (Rule Evaluation - Firing Strengths)
            // Tanımlı her bir kural için (27 tane), kuralın IF kısmındaki koşulların
            // bulanıklaştırılmış üyelik derecelerinin minimumunu (AND operatörü) alarak
            // o kuralın ateşleme gücünü (α) hesapla.
            var firingStrengths = rules.Select(rule => rule.CalculateFiringStrength(fuzzifiedInputs)).ToList();

            // 3. ADIM: Durulaştırma (Defuzzification - Weighted Average)
            // Her bir çıkış değişkeni (Dönüş Hızı, Süre, Deterjan) için,
            // ateşlenen kuralların çıktılarını (THEN kısmı) ve ateşleme güçlerini kullanarak
            // ağırlıklı ortalama yöntemiyle net bir çıkış değeri hesapla.
            var crispOutputs = new Dictionary<string, double>
            {
                { FuzzyLogicDefinitions.SpinSpeed.Name, DefuzzifyWeightedAverage(firingStrengths, FuzzyLogicDefinitions.SpinSpeed) },
                { FuzzyLogicDefinitions.Duration.Name, DefuzzifyWeightedAverage(firingStrengths, FuzzyLogicDefinitions.Duration) },
                { FuzzyLogicDefinitions.Detergent.Name, DefuzzifyWeightedAverage(firingStrengths, FuzzyLogicDefinitions.Detergent) }
            };

            // 4. ADIM: Centroid Yöntemi İçin Grafik ve Hesaplama Verileri Oluştur
            var outputMembershipValues = new Dictionary<string, OutputMembershipData>();
            
            // Dönüş Hızı için grafik verileri ve centroid hesabı
            var spinSpeedResult = CalculateCentroidAndGraphData(firingStrengths, FuzzyLogicDefinitions.SpinSpeed);
            outputMembershipValues.Add(FuzzyLogicDefinitions.SpinSpeed.Name, spinSpeedResult);
            
            // Süre için grafik verileri ve centroid hesabı
            var durationResult = CalculateCentroidAndGraphData(firingStrengths, FuzzyLogicDefinitions.Duration);
            outputMembershipValues.Add(FuzzyLogicDefinitions.Duration.Name, durationResult);
            
            // Deterjan için grafik verileri ve centroid hesabı
            var detergentResult = CalculateCentroidAndGraphData(firingStrengths, FuzzyLogicDefinitions.Detergent);
            outputMembershipValues.Add(FuzzyLogicDefinitions.Detergent.Name, detergentResult);

            // Centroid yöntemi sonuçlarını topla
            var centroidOutputs = new Dictionary<string, double>
            {
                { FuzzyLogicDefinitions.SpinSpeed.Name, spinSpeedResult.CentroidPoint },
                { FuzzyLogicDefinitions.Duration.Name, durationResult.CentroidPoint },
                { FuzzyLogicDefinitions.Detergent.Name, detergentResult.CentroidPoint }
            };

            // Hesaplanan tüm değerleri içeren sonucu döndür
            return new FuzzyResult(
                crispOutputs, 
                centroidOutputs, 
                firingStrengths, 
                fuzzifiedInputs,
                outputMembershipValues);
        }


        /// <summary>
        /// Verilen net giriş değerleri için sadece net çıkış değerlerini hesaplar (Kolay kullanım için).
        /// </summary>
        public Dictionary<string, double> Calculate(double sensitivity, double amount, double dirtiness)
        {
            // Detaylı hesaplamayı yap ve sadece net çıktıları al.
            return CalculateDetailed(sensitivity, amount, dirtiness).CrispOutputs;
        }


        /// <summary>
        /// Belirli bir çıkış değişkeni için Ağırlıklı Ortalama yöntemine göre durulaştırma yapar.
        /// Formül: Σ(αᵢ * cᵢ) / Σ(αᵢ)
        /// αᵢ = i. kuralın ateşleme gücü
        /// cᵢ = i. kuralın önerdiği çıktı kümesinin temsilci değeri (merkezi/tepesi)
        /// </summary>
        /// <param name="firingStrengths">Tüm kuralların ateşleme güçleri listesi.</param>
        /// <param name="outputVariable">Durulaştırılacak çıkış değişkeni (örn: Dönüş Hızı).</param>
        /// <returns>Hesaplanan net çıkış değeri.</returns>
        private double DefuzzifyWeightedAverage(List<double> firingStrengths, LinguisticVariable outputVariable)
        {
            double weightedSum = 0; // Formülün payı: Σ(αᵢ * cᵢ)
            double firingSum = 0;   // Formülün paydası: Σ(αᵢ)

            // Tüm kurallar (1'den 27'ye) için döngü
            for (int i = 0; i < rules.Count; i++)
            {
                double strength = firingStrengths[i]; // i. kuralın ateşleme gücü (αᵢ)

                // Eğer kural ateşlenmişse (gücü > 0) VE bu kuralın sonucu ilgili çıkış değişkenini içeriyorsa
                if (strength > 0 && rules[i].Consequents.TryGetValue(outputVariable.Name, out string outputSetName))
                {
                    // Kuralın önerdiği çıktı kümesini (örn: "Orta") bul
                    if (outputVariable.Sets.TryGetValue(outputSetName, out FuzzySet outputSet))
                    {
                        // Kümenin temsilci değerini (cᵢ) al (üçgen için tepe, yamuk için merkez)
                        double representativeValue = outputSet.RepresentativeValue;

                        // Toplamlara ekle
                        weightedSum += strength * representativeValue;
                        firingSum += strength;
                    }
                    else
                    {
                        // Hata durumu: Kuralda var ama değişkende tanımlı olmayan bir küme adı.
                        // Bu normalde olmamalı. Geliştirme sırasında kontrol için loglama.
                        Console.WriteLine($"Uyarı: Durulaştırma sırasında {outputVariable.Name} değişkeninde {outputSetName} kümesi bulunamadı.");
                    }
                }
            }

            // Sonucu hesapla. Eğer toplam ateşleme gücü 0 ise (hiçbir kural ateşlenmediyse),
            // 0'a bölme hatasını önlemek için sonucu 0 olarak döndür.
            return (firingSum > 0) ? (weightedSum / firingSum) : 0;
        }

        /// <summary>
        /// Centroid (Ağırlık Merkezi) yöntemi için hesaplama yapar.
        /// Çıkış değişkeninin x,y değerlerini ve centroid'ini döndürür.
        /// </summary>
        /// <param name="firingStrengths">Tüm kuralların ateşleme güçleri listesi.</param>
        /// <param name="outputVariable">Durulaştırılacak çıkış değişkeni (örn: Dönüş Hızı).</param>
        /// <returns>X,Y değerleri ve centroid'i içeren nesne.</returns>
        private OutputMembershipData CalculateCentroidAndGraphData(List<double> firingStrengths, LinguisticVariable outputVariable)
        {
            // Değişkenin aralığını çıktı üyelik fonksiyonlarına göre belirle
            double min = double.MaxValue;
            double max = double.MinValue;

            // Değişkenin tanım aralığını bul (tüm kümelerin min-max aralığı)
            foreach (var set in outputVariable.Sets.Values)
            {
                // Üyelik fonksiyonunun tanım aralığını al
                if (set.MembershipFunction is TriangleMembershipFunction triangle)
                {
                    min = Math.Min(min, triangle.GetLeftBound());
                    max = Math.Max(max, triangle.GetRightBound());
                }
                else if (set.MembershipFunction is TrapezoidMembershipFunction trapezoid)
                {
                    min = Math.Min(min, trapezoid.GetLeftBound());
                    max = Math.Max(max, trapezoid.GetRightBound());
                }
            }

            // X ekseninde örnekleme noktaları oluştur
            double[] xValues = new double[SamplingPoints];
            double[] yValues = new double[SamplingPoints];
            double step = (max - min) / (SamplingPoints - 1);

            // Her x değeri için maksimum üyelik fonksiyonu değerini hesapla
            for (int i = 0; i < SamplingPoints; i++)
            {
                double x = min + i * step;
                xValues[i] = x;
                yValues[i] = 0;

                // Tüm kurallar üzerinde döngü
                for (int ruleIndex = 0; ruleIndex < rules.Count; ruleIndex++)
                {
                    double strength = firingStrengths[ruleIndex];
                    if (strength > 0 && rules[ruleIndex].Consequents.TryGetValue(outputVariable.Name, out string outputSetName))
                    {
                        if (outputVariable.Sets.TryGetValue(outputSetName, out FuzzySet outputSet))
                        {
                            // Mamdani min operatörü (üyelik fonksiyonu ile ateşleme gücünün minimumu)
                            double membership = Math.Min(outputSet.GetMembership(x), strength);
                            // Maksimum birleştirme (OR operatörü)
                            yValues[i] = Math.Max(yValues[i], membership);
                        }
                    }
                }
            }

            // Centroid (Ağırlık Merkezi) hesabı
            // Formül: ∫(μ(x) * x) / ∫μ(x) (Nümerik integral kullanılır)
            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < SamplingPoints; i++)
            {
                numerator += xValues[i] * yValues[i];
                denominator += yValues[i];
            }

            // Eğer paydada 0 varsa (hiç bir üyelik yok) orta noktayı döndür
            double centroidPoint = denominator > 0 ? numerator / denominator : (min + max) / 2;

            return new OutputMembershipData(xValues, yValues, centroidPoint);
        }
    }
}