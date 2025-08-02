using System;

// Namespace'in proje adıyla aynı olduğundan emin ol
namespace bulanik_mantik_severge7
{
    // Üyelik fonksiyonları için temel arayüz
    public interface IMembershipFunction
    {
        double GetMembership(double x);
        double Center { get; } // Durulaştırma için tepe/merkez noktası
    }

    // Üçgen üyelik fonksiyonu
    public class TriangleMembershipFunction : IMembershipFunction
    {
        private double a, b, c; // Köşe noktaları: a=başlangıç, b=tepe, c=bitiş
        public double Center => b;

        public TriangleMembershipFunction(double a, double b, double c)
        {
            this.a = a; this.b = b; this.c = c;
        }

        public double GetMembership(double x)
        {
            if (x <= a || x >= c) return 0;
            if (x == b) return 1;
            if (x > a && x < b) return (x - a) / (b - a);
            return (c - x) / (c - b); // else: x > b && x < c
        }
        
        // Üyelik fonksiyonunun sol sınırını (tanım aralığının başlangıcı) döndürür
        public double GetLeftBound() => a;
        
        // Üyelik fonksiyonunun sağ sınırını (tanım aralığının sonu) döndürür
        public double GetRightBound() => c;
    }

    // Yamuk üyelik fonksiyonu
    public class TrapezoidMembershipFunction : IMembershipFunction
    {
        private double a, b, c, d; // Köşe noktaları: a=başlangıç, [b,c]=tepe, d=bitiş
        public double Center => (b + c) / 2.0;

        public TrapezoidMembershipFunction(double a, double b, double c, double d)
        {
            this.a = a; this.b = b; this.c = c; this.d = d;
        }

        public double GetMembership(double x)
        {
            if (x <= a || x >= d) return 0;
            if (x >= b && x <= c) return 1;
            if (x > a && x < b) return (x - a) / (b - a);
            return (d - x) / (d - c); // else: x > c && x < d
        }
        
        // Üyelik fonksiyonunun sol sınırını (tanım aralığının başlangıcı) döndürür
        public double GetLeftBound() => a;
        
        // Üyelik fonksiyonunun sağ sınırını (tanım aralığının sonu) döndürür
        public double GetRightBound() => d;
    }
}