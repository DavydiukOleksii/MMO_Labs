using System;

namespace laba_3
{
    public static class PolovynigiDilenia
    {
        public static double GetMin(Func<double, double> f, double a, double b, double eps)
        {
            double L, x1, xm, x2, y1, ym, y2;
            do
            {
                xm = (a + b) / 2;
                x1 = (a + xm) / 2;
                x2 = (xm + b) / 2;

                ym = f(xm);
                y1 = f(x1);
                y2 = f(x2);

                if (y1 < ym)
                {
                    b = xm;
                }
                else
                {
                    if (y2 < ym)
                    {
                        a = xm;
                    }
                    else
                    {
                        a = x1;
                        b = x2;
                    }
                }

                L = b - a;
            } while (L > eps);
            return xm;
        }   
    }
}
