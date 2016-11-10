using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect.Metods
{
    public class Dihotomii
    {
        double a, b, L, x1, xm, x2, y1, ym, y2, E;
        short type = 1;

        public Dihotomii(double a, double b, double E, string type)
        {
            this.a = a;
            this.b = b;
            this.E = E;

            if (type == "max") this.type *= (-1);
        }

        public void Calculate() 
        {
            int k = 0;
            Console.WriteLine("Metod Dyhotomii");

            Console.WriteLine(" --------------------------------------------------------------------");
            Console.WriteLine("  k |   a   |   b   |   L   |   x1  |  xm   |  x2   |   y1   |   y2  |");
            Console.WriteLine(" --------------------------------------------------------------------");
            do
            {
                xm = (a + b) / 2;
                x1 =  xm - E / 2;
                x2 = xm +  E / 2;

                y1 = type * Function.func(x1);
                y2 = type * Function.func(x2);

                if (y1 < y2)
                {
                    b = xm;
                }
                else 
                {
                    a = xm; 
                }

                L = b - a;
                k++;
                Console.WriteLine(" {0,3:0.}|{1,6:0.000} |{2,6:0.000} | {3,5:0.000} |{4,6:0.000} |{5,6:0.000} |{6,6:0.000} | {7,6:0.000} |{8,6:0.000} |", k, a, b, L, x1, xm, x2, y1, y2);
            }while(L > E);

            Console.WriteLine(" --------------------------------------------------------------------");
            Console.WriteLine("\tX* = {0:0.000}", ((a + b) / 2));
            Console.WriteLine();
        }
    }
}
