using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace laba_3
{
    public class Function
    {
        public Func<double, int, int, double> fi { private get; set; }
        public Func<double, int, int, double> fdxi { private get; set; }
        public Func<double, double> f0 { private get; set; } 

        public double Fi(double xi, int i, int n) { return fi(xi, i, n); }

        public double Fdxi(double xi, int i, int n) { return fdxi(xi, i, n); }

        public double F0(double i) { return f0(i); } 

        public double F(List<double> x)
        {
            double resoult = 0;
            for (int i = 0; i < x.Count; i++)
            {
                resoult += fi(x[i], i + 1, x.Count);
            }
            return resoult;
        }

        public List<double> Fdx(List<double> x)
        {
            List<double> resoult = new List<double>();
            for (int i = 0; i < x.Count; i++)
            {
                resoult.Add(fdxi(x[i], i + 1, x.Count));
            }
            return resoult;
        }

        public double Norma(List<double> x){ return Math.Sqrt( x.Sum(t => Math.Pow(t, 2))); }
    }
}
