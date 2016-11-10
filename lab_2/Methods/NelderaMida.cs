using System;
using System.Collections.Generic;
using System.Linq;

namespace Function.Methods
{
    public static class NelderaMida
    {
        public static void Calculete(double E, double a, double b, double y, double x1b, double x2b)
        {
            #region Pochatkovi ymovu
            X x1 = new X(x1b, x2b);
            X x2 = new X(x1b + a, x2b);
            X x3 = new X(x1b, x2b + a);
            X xotr = new X(0, 0);
            X xrast = new X(0, 0);
            X xszhat = new X(0, 0);

            double x1Center;
            double x2Center;

            double end = 0;

            List<X> x = new List<X> { x1, x2, x3 };
            #endregion

            do
            {
                #region Sort i vuvod
                x = x.OrderBy(ex => ex.y).ToList();

                for (int i = 0; i < x.Count; i++ )
                {
                    Console.WriteLine("x[{0}] = {1:8.000}  \tf(x) = {2:0.000}", i, x[i],x[i].y);
                }
                Console.WriteLine();
                #endregion

                #region Vuznachaem center vag
                x1Center = 0;
                x2Center = 0;
                for(int i = 0; i < x.Count - 1; i++)
                {
                    x1Center += x[i].x1;
                    x2Center += x[i].x2;
                }
                X xcenter = new X(x1Center / (x.Count - 1), x2Center / (x.Count - 1));

                //System.Console.WriteLine("\nx = " + xcenter + "\tf(x) = " + xcenter.y);
                #endregion

                #region Vuznachem x otrazhone
                xotr = xcenter + xcenter * a - x.Last() * a;
                //System.Console.WriteLine("\notr = " + xotr + "\t y = " + xotr.y);
                #endregion

                #region Zminuemo formy

                #region Rostagyvania
                if (xotr.y < x.First().y)
                {
                    xrast = xcenter + xotr * y - xcenter * y;

                    if (xrast.y < xotr.y)
                    {
                        x[x.Count - 1] = xrast;
                    }
                    else 
                    {
                        x[x.Count - 1] = xotr;
                    }
                }
                #endregion
                else
                {
                    #region Szatia
                    if (x.First().y <= xotr.y && xotr.y < x.Last().y)
                    {
                        xszhat = xcenter + x.Last() * b - xcenter * b;

                        if (xszhat.y < xotr.y)
                        {
                            x[x.Count - 1] = xszhat;
                        }
                        else
                        {
                            x[x.Count - 1] = xotr;
                        }
                    }
                    #endregion
                    #region redukzia
                    else
                    {
                        if(xotr.y >= x.Last().y)
                        {
                            for(int i = 1; i < x.Count; i++)
                            {
                                x[i] = x.First() + x[i] * 0.5 - x.First() * 0.5;
                            }
                        }
                    }
                    #endregion
                }
                #endregion  

                #region PerevirkaVuhody
                end = 0;

                for (int i = 0; i < x.Count; i++)
                {
                    end += Math.Pow(x[i].y - xcenter.y, 2);
                }
                end = Math.Sqrt(end / x.Count);
                #endregion

            } while(end > E);

            Console.WriteLine("\noptimize x = " + x.First() + "\ty = " + x.First().y );
        }
    }
}
