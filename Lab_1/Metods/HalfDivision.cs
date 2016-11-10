namespace Progect.Metods
{
    public class HalfDivision
    {
        double a, b, L, x1, xm, x2, y1, ym, y2, E;
        short type = 1;

        public HalfDivision(double a, double b, double E, string type)
        {
            this.a = a;
            this.b = b;
            this.E = E;

            if (type == "max") this.type *= (-1);
        }

        public void Calculate() 
        {
            int k = 0;
            System.Console.WriteLine("Metod Polovynogo dilenia");
            System.Console.WriteLine(" ----------------------------------------------------------------------------");
            System.Console.WriteLine("  k |   a   |   b   |   L   |   x1  |  xm   |  x2   |   y1   |   ym  |   y2  |");
            System.Console.WriteLine(" ----------------------------------------------------------------------------");
            do
            {
                xm = (a + b) / 2;
                x1 = (a + xm) / 2;
                x2 = (xm + b) / 2;

                ym = type * Function.func(xm);
                y1 = type * Function.func(x1);
                y2 = type * Function.func(x2);

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
                k++;
                System.Console.WriteLine(" {0,3:0.}|{1,6:0.000} |{2,6:0.000} | {3,5:0.000} |{4,6:0.000} |{5,6:0.000} |{6,6:0.000} | {7,6:0.000} |{8,6:0.000} |{9,6:0.000} |", k, a, b, L, x1, xm, x2, y1, ym, y2);
            }while(L > E);

            System.Console.WriteLine(" ----------------------------------------------------------------------------");

            System.Console.WriteLine("\tX* = {0:0.000}", ((a+b)/2));
            System.Console.WriteLine();

        }
    }
}
