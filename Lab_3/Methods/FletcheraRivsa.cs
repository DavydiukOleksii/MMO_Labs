using System;

namespace laba_3.Methods
{
    public class FletcheraRivsa
    {
        public static X GetMin(Function f, X x0, double Lambda, double eps)
        {
            X x = x0;
            X x_prev = x;
            int k = 0;
            X d = new X(0, 0);

            double Betta = 0;
            Console.WriteLine(new String('-', 70));
            Console.WriteLine("{0,41}{1,30}", "Fletchera Rivsa", "|");
            Console.WriteLine(new String('-', 70) + "|");
            
            Console.WriteLine("{0,3} |{1,16} |{2,8} |{3,8} |{4,16} |{5,8} |", "k", "x", "y", "Lambda", "G", "Norma");
            Console.WriteLine("{0}{2}{1}{1}{2}{1}", "----|", "---------|", "-----------------|");


            while (f.Norma(x) > eps)
            {
                Console.WriteLine("{0,3} |{1,16} |{2,8:0.0000} |{3,8:0.00} |{4,16} |{5,8:0.000} |",
                    k, x, f.F(x), Lambda, new X(f.Fdx1(x), f.Fdx2(x)), f.Norma(x));
                
                if (k == 0)
                {
                    //5
                    d = new X(-f.Fdx1(x0), -f.Fdx2(x0));
                }
                else
                {
                    {
                        Betta = Math.Pow(f.Norma(x), 2) / Math.Pow(f.Norma(x_prev), 2);
                    }
                }

                //7
                d = new X(-f.Fdx1(x) + Betta * d.X1, -f.Fdx2(x) + Betta * d.X2);

                //8
                Lambda = PolovynigiDilenia.GetMin((lambda) => f.F(new X(x.X1 + lambda * d.X1, x.X2 + lambda * d.X2)), -100, 100, 0.1);

                //9
                x_prev = x;
                x = new X(x.X1 + Lambda * d.X1, x.X2 + Lambda * d.X2);

                //10
                k++;
            }
            Console.WriteLine(new String('-', 70));
            return x;
        }
    }
}
