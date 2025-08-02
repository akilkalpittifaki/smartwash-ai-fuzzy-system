using System.Collections.Generic;

// Namespace'in proje adıyla aynı olduğundan emin ol
namespace bulanik_mantik_severge7
{
    // Tek bir bulanık kümeyi temsil eder
    public class FuzzySet
    {
        public string Name { get; }
        public IMembershipFunction MembershipFunction { get; }
        public double RepresentativeValue => MembershipFunction.Center;

        public FuzzySet(string name, IMembershipFunction membershipFunction)
        {
            Name = name; MembershipFunction = membershipFunction;
        }
        public double GetMembership(double x) => MembershipFunction.GetMembership(x);
    }

    // Bir dilsel değişkeni ve kümelerini gruplar
    public class LinguisticVariable
    {
        public string Name { get; }
        public Dictionary<string, FuzzySet> Sets { get; }

        public LinguisticVariable(string name)
        {
            Name = name; Sets = new Dictionary<string, FuzzySet>();
        }
        public void AddSet(FuzzySet set) => Sets.Add(set.Name, set);

        public Dictionary<string, double> Fuzzify(double crispValue)
        {
            var memberships = new Dictionary<string, double>();
            foreach (var set in Sets.Values)
            {
                memberships.Add(set.Name, set.GetMembership(crispValue));
            }
            return memberships;
        }
    }

    // Tüm bulanık sistemi tanımlarını içerir
    public static class FuzzyLogicDefinitions
    {
        // Girdi ve Çıktı Değişkenleri
        public static LinguisticVariable Sensitivity { get; private set; }
        public static LinguisticVariable Amount { get; private set; }
        public static LinguisticVariable Dirtiness { get; private set; }
        public static LinguisticVariable SpinSpeed { get; private set; }
        public static LinguisticVariable Duration { get; private set; }
        public static LinguisticVariable Detergent { get; private set; }

        static FuzzyLogicDefinitions() => InitializeVariables();

        // Değişkenleri ve kümeleri PDF'teki tablolara göre başlatır
        private static void InitializeVariables()
        {
            // --- GİRİŞ DEĞİŞKENLERİ ---
            Sensitivity = new LinguisticVariable("Hassaslık");
            Sensitivity.AddSet(new FuzzySet("Sağlam", new TrapezoidMembershipFunction(-4, -1.5, 2, 4)));
            Sensitivity.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(3, 5, 7)));
            Sensitivity.AddSet(new FuzzySet("Hassas", new TrapezoidMembershipFunction(5.5, 8, 12.5, 14)));

            Amount = new LinguisticVariable("Miktar");
            Amount.AddSet(new FuzzySet("Küçük", new TrapezoidMembershipFunction(-4, -1.5, 2, 4)));
            Amount.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(3, 5, 7)));
            Amount.AddSet(new FuzzySet("Büyük", new TrapezoidMembershipFunction(5.5, 8, 12.5, 14)));

            Dirtiness = new LinguisticVariable("Kirlilik");
            Dirtiness.AddSet(new FuzzySet("Küçük", new TrapezoidMembershipFunction(-4.5, -2.5, 2, 4.5)));
            Dirtiness.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(3, 5, 7)));
            Dirtiness.AddSet(new FuzzySet("Büyük", new TrapezoidMembershipFunction(5.5, 8, 12.5, 15)));

            // --- ÇIKIŞ DEĞİŞKENLERİ ---
            SpinSpeed = new LinguisticVariable("Dönüş Hızı");
            SpinSpeed.AddSet(new FuzzySet("Hassas", new TrapezoidMembershipFunction(-5.8, -2.8, 0.5, 1.5)));
            SpinSpeed.AddSet(new FuzzySet("Normal-Hassas", new TriangleMembershipFunction(0.5, 2.75, 5)));
            SpinSpeed.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(2.75, 5, 7.25)));
            SpinSpeed.AddSet(new FuzzySet("Normal-Güçlü", new TriangleMembershipFunction(5, 7.25, 9.5)));
            SpinSpeed.AddSet(new FuzzySet("Güçlü", new TrapezoidMembershipFunction(8.5, 9.5, 12.8, 15.2)));

            Duration = new LinguisticVariable("Süre");
            Duration.AddSet(new FuzzySet("Kısa", new TrapezoidMembershipFunction(-46.5, -25.28, 22.3, 39.9)));
            Duration.AddSet(new FuzzySet("Normal-Kısa", new TriangleMembershipFunction(22.3, 39.9, 57.5)));
            Duration.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(39.9, 57.5, 75.1)));
            Duration.AddSet(new FuzzySet("Normal-Uzun", new TriangleMembershipFunction(57.5, 75.1, 92.7)));
            Duration.AddSet(new FuzzySet("Uzun", new TrapezoidMembershipFunction(75, 92.7, 111.6, 130)));

            Detergent = new LinguisticVariable("Deterjan Miktarı");
            Detergent.AddSet(new FuzzySet("Çok Az", new TrapezoidMembershipFunction(0, 0, 20, 85)));
            Detergent.AddSet(new FuzzySet("Az", new TriangleMembershipFunction(20, 85, 150)));
            Detergent.AddSet(new FuzzySet("Orta", new TriangleMembershipFunction(85, 150, 215)));
            Detergent.AddSet(new FuzzySet("Fazla", new TriangleMembershipFunction(150, 215, 280)));
            Detergent.AddSet(new FuzzySet("Çok Fazla", new TrapezoidMembershipFunction(215, 280, 300, 300)));
        }
    }
}