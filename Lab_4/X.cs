using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba_3
{
    public class X
    {
        public List<double> XList = new List<double>();
        public List<double> XdxList = new List<double>();

        public Function f = Program.f;

        public X(X x)
        {
            if (x.XList != null)
            {
                XList.Clear();
                foreach (var xi in x.XList)
                {
                    XList.Add(xi);
                }
            }

            if (x.XdxList != null)
            {
                foreach (var xi in x.XdxList)
                {
                    XdxList.Add(xi);
                }
            }
        }

        public X(List<double> x)
        {
            XList.Clear();
            for (int i = 0; i < x.Count; i++)
            {
                XList.Add(x[i]);
                XdxList.Add(f.Fdxi(x[i], i + 1, x.Count));
            }
        }

        public X(int n, Function f)
        {
            this.f = f;
            XList.Clear();
            for (int i = 0; i < n; i++)
            {
                XList.Add(f.F0(i + 1));
                XdxList.Add(f.Fdxi(XList[i], i + 1, n));
            }
        }
        
        public static X operator+ (X a, X b)
        {
            List<double> tmp = a.XList.Select((t, i) => t + b.XList[i]).ToList();
            return new X(tmp);
        }

        public static X operator- (X a, X b)
        {
            List<double> tmp = a.XList.Select((t, i) => t - b.XList[i]).ToList();
            return new X(tmp);
        }

        public static X operator/ (X a, double b)
        {
            List<double> tmp = a.XList.Select((t, i) => t + b).ToList();
            return new X(tmp);
        }

        public static X operator* (double b, X a)
        {
            List<double> tmp = a.XList.Select((t, i) => t * b).ToList();
            return new X(tmp);
        }

        public override string ToString()
        {
            StringBuilder resoult = new StringBuilder("");
            for (int i = 0; i < XList.Count; i++)
            {
                resoult.Append(String.Format("{0:0.0000}", XList[i]));
                if (i != XList.Count - 1) resoult.Append(": ");
            }

            return resoult.ToString();
        }
    }
}
