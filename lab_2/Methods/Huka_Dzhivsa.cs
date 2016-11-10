using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function;

namespace Function.Methods
{
    public static class Huka_Dzhivsa
    {
        public static void Calculete(double E, double dx, double a, double x1b, double x2b) 
        {
            X xb = new X(x1b, x2b);
            X xiter = new X(x1b, x2b);
            X xtmp = new X(0, 0);

            double yb = Function.func(xb);
            double ymin = yb;

            Console.WriteLine("Basic point: " + xb.ToString() + "\tf(X) = " + Function.func(xb));

            while ( dx > E)
            {
                xiter = xb;

                #region x1 change
                xtmp.x1 = -dx;
                if (ymin > Function.func(xtmp + xiter) && Function.func(xtmp + xiter) < Function.func(xtmp - xiter)) 
                {
                    ymin = Function.func(xtmp + xiter);
                }
                else
                {
                    xtmp.x1 = dx;
                    if (ymin < Function.func(xtmp + xiter))
                    {
                      xtmp.x1 = 0;
                    }
                }
                #endregion

                #region x2 change
                xtmp.x2 = -dx;
                if (ymin > Function.func(xtmp + xiter) && Function.func(xtmp + xiter) < Function.func(xtmp - xiter))
                {
                    xiter += xtmp;
                }
                else
                {
                    xtmp.x2 = dx;
                    if (ymin > Function.func(xtmp + xiter))
                    {
                        xiter += xtmp;
                    }
                    else
                    {
                        xtmp.x2 = 0;
                        if (xtmp.x1 == 0) 
                        {
                            dx = dx / 2;
                            Console.WriteLine("\tChange dX = " + dx);
                            continue;
                        }
                    }
                }
                ymin = Function.func(xiter);
                #endregion

                Console.WriteLine("\tNew vector: " + xtmp.ToString());

                while(Function.func(xiter) < Function.func(xb))
                {
                    xb = xiter;
                    xiter += xtmp;
                    Console.WriteLine("New basic point: " + xb.ToString() + "\tf(X) = " + Function.func(xb));
                }
                xtmp.x2 = 0;
            }
            Console.WriteLine("\nThe optimize point: " + xb.ToString() + "\t f(" + xb.x1 + ";" + xb.x2 +") = " + Function.func(xb));
        }
    }
}
