using System;

namespace Progect.Metods
{
    public class GoldCut
    {
        double a, b, L, x1, x2, y1, y2, E;
        short type = 1;

        public GoldCut(double a, double b, double E, string type)
        {
            this.a = a;
            this.b = b;
            this.E = E;

            if (type == "max") this.type *= (-1);
        }

        public void Calculate() 
        {
            int k = 0;
            Console.WriteLine("Metod Zolotogo pererizu");
            Console.WriteLine(" -------------------------------------------------------------");
            Console.WriteLine("  k |   a   |   b   |   L   |   x1   |  x2   |   y1   |   y2  |");
            Console.WriteLine(" -------------------------------------------------------------");
            do
            {
                x1 = a + ((3 - Math.Sqrt(5)) * (b - a)) / 2;
                x2 = a + ((Math.Sqrt(5) - 1) * (b - a)) / 2;

                y1 = type * Function.func(x1);
                y2 = type * Function.func(x2);

                if (y1 < y2)
                {
                    b = x2;
                }
                else 
                {
                    a = x1; 
                }

                L = b - a;
                k++;
                Console.WriteLine(" {0,3:0.}|{1,6:0.000} |{2,6:0.000} | {3,5:0.000} |{4,6:0.000} |{5,6:0.000} |{6,6:0.000} | {7,6:0.000} |", k, a, b, L, x1, x2, y1, y2);
            }while(L > E);

            Console.WriteLine(" -------------------------------------------------------------");
            Console.WriteLine("\tX* = {0:0.000}", ((a + b) / 2));
            Console.WriteLine();

        }
    }
}
