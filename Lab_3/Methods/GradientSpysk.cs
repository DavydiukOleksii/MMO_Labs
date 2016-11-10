using System;

namespace laba_3.Methods
{
    public class GradientSpysk
    {
        public static X GetMin(Function f, X x0, double Lambda, double eps)
        {
            X x = x0;
            X temp;
            int k = 0;

            Console.WriteLine(new String('-', 70));
            Console.WriteLine("{0,41}{1,30}", "Gradient Spysk", "|");
            Console.WriteLine(new String('-', 70) + "|");


            Console.WriteLine("{0,3} |{1,16} |{2,8} |{3,8} |{4,16} |{5,8} |", "k", "x", "y", "Lambda", "G", "Norma");
            Console.WriteLine("{0}{2}{1}{1}{2}{1}", "----|", "---------|", "-----------------|");

            while (f.Norma(x) > eps)
            {
                Console.WriteLine("{0,3} |{1,16} |{2,8:0.0000} |{3,8:0.00} |{4,16} |{5,8:0.000} |", 
                    k, x, f.F(x), Lambda, new X(f.Fdx1(x), f.Fdx2(x)), f.Norma(x));

                double norma = f.Norma(x);
                temp = new X(x.X1 - Lambda * f.Fdx1(x), x.X2 - Lambda * f.Fdx2(x));
                if (f.F(temp) < f.F(x))
                {
                    k++;
                    x = temp;
                    continue;
                }
                else
                    Lambda /= 2;
            }
            Console.WriteLine(new String('-', 70));
            return x;
        }
    }
}
