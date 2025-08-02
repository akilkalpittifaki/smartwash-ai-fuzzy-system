using System; // Console.WriteLine için
using System.Collections.Generic;

// Namespace'in proje adıyla aynı olduğundan emin ol
namespace bulanik_mantik_severge7
{
    // Tek bir bulanık mantık kuralını temsil eder
    public class FuzzyRule
    {
        public Dictionary<string, string> Antecedents { get; } // IF kısmı
        public Dictionary<string, string> Consequents { get; } // THEN kısmı

        public FuzzyRule()
        {
            Antecedents = new Dictionary<string, string>();
            Consequents = new Dictionary<string, string>();
        }

        public FuzzyRule AddAntecedent(string variableName, string setName)
        {
            Antecedents.Add(variableName, setName); return this;
        }

        public FuzzyRule AddConsequent(string variableName, string setName)
        {
            Consequents.Add(variableName, setName); return this;
        }

        // Kuralın ateşleme gücünü hesaplar (Mamdani min operatörü)
        public double CalculateFiringStrength(Dictionary<string, Dictionary<string, double>> fuzzifiedInputs)
        {
            double minMembership = 1.0;
            foreach (var antecedent in Antecedents)
            {
                if (fuzzifiedInputs.TryGetValue(antecedent.Key, out var variableMemberships) &&
                    variableMemberships.TryGetValue(antecedent.Value, out double membership))
                {
                    if (membership < minMembership) minMembership = membership;
                }
                else
                {
                    // Bu durum normalde olmamalı, hata ayıklama için loglama
                    Console.WriteLine($"Uyarı: Kuralda {antecedent.Key}={antecedent.Value} için üyelik bulunamadı.");
                    return 0.0; // Kural ateşlenemez
                }
            }
            return minMembership;
        }
    }
}