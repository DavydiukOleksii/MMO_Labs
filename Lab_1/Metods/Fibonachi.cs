using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect.Metods
{
    public class Fibonachi
    {
        double a, b, L, x1, x2, y1, y2, E;
        short type = 1;

        public Fibonachi(double a, double b, double E, string type)
        {
            this.a = a;
            this.b = b;
            this.E = E;

            if (type == "max") this.type *= (-1);
        }

        public void Calculate()
        {
           Console.WriteLine("Metod Fibonachi");
           Console.WriteLine(" -------------------------------------------------------------");
           Console.WriteLine("  k |   a   |   b   |   L   |  x1   |  x2   |  y1   |   y2   |");
           Console.WriteLine(" -------------------------------------------------------------");

           List<double> F = GeneratorFibonachi.GetFibonachi(b).Select( (x) => (double)x ).ToList();
           int N = F.Count - 1;
           int k = 1;

           x1 = a + (F[N - 2] / F[N]) * (b - a);
           x2 = a + (F[N - 1] / F[N]) * (b - a);

           do
           {
               
               y1 = type * Function.func(x1);
               y2 = type * Function.func(x2);

               if (y1 <= y2)
               {
                   b = x2;
                   x2 = x1;
                   x1 = a + (F[N - k - 2] / F[N - k]) * (b - a);
               }
               else 
               {
                   a = x1;
                   x1 = x2;
                   x2 = a + (F[N - k - 1] / F[N - k]) * (b - a);
               }

               L = b - a;
               k++;

               Console.WriteLine(" {0,3:0.}|{1,6:0.000} |{2,6:0.000} | {3,5:0.000} |{4,6:0.000} |{5,6:0.000} |{6,6:0.000} | {7,6:0.000} |", k - 1, a, b, L, x1, x2, y1, y2);
            } while (k != N - 2 + 1);

           x1 = (a + b) / 2;
           x2 = x1 + E;

           y1 = type * Function.func(x1);
           y2 = type * Function.func(x2);

           if (y1 <= y2)
           {
               b = x2;
           }
           else
           {
               a = x1;
           }

            Console.WriteLine(" -------------------------------------------------------------");

            Console.WriteLine("\tX* = {0:0.000}", ((a+b)/2));
            Console.WriteLine();
        }
    }
}
