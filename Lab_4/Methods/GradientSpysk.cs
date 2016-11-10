using System;
using System.Diagnostics;

namespace laba_3.Methods
{
    public class GradientSpysk
    {
        public static string GetMin(Function f, X x0, double Lambda, double eps)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            X x = x0;
            X temp;
            int k = 0;

            while (f.Norma(x.XdxList) > eps)
            {
                temp = new X(x - Lambda * (new X(f.Fdx(x.XList))));
                if (f.F(temp.XList) < f.F(x.XList))
                {
                    k++;
                    x = temp;
                    continue;
                }
                else
                    Lambda /= 2;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            return String.Format("{0,6:0.0000}", ts.TotalSeconds); ;
        }
    }
}
