using System;
using laba_3.Methods;

namespace laba_3
{
    class Program
    {
        static Function f = new Function
        {
            f = (x1, x2) => Math.Pow((x1 - 2), 2) + Math.Pow((x2 - 4), 2),
            fdx1 = (x1, x2) => 2 * x1 - 4,
            fdx2 = (x1, x2) => 2 * x2 - 8
        };

        static X x0 = new X(1.2, 3.4);

        static void Main(string[] args)
        {
            X gs = GradientSpysk.GetMin(f, x0, 0.1, 0.001);
            Console.WriteLine("F(x) => min When x = " + gs);
            Console.WriteLine();

            X fgs = FastGradientSpysk.GetMin(f, x0, 0.1, 0.001);
            Console.WriteLine("F(x) => min When x = " + fgs);
            Console.WriteLine();

            X fr = FletcheraRivsa.GetMin(f, x0, 0.1, 0.001);
            Console.WriteLine("F(x) => min When x = " + fr);

            Console.ReadKey();
        }
    }
}
