using System;
using laba_3.Methods;

namespace laba_3
{
    class Program
    {
        public static Function f = new Function()
        {
            fi = (xi, i, n) => Math.Pow(xi - n, 2)/(i*i),
            fdxi = (xi, i, n) => (xi * 2  - 2 * n) / (i * i),
            f0 = i => 2 * i
        };

        static void Main(string[] args)
        {
            Console.WriteLine(new String('-', 16));
            Console.WriteLine("| {0,3} | {1,6} |", "N", "Second");
            Console.WriteLine(new String('-', 16));

            for (int i = 2; i < 31; i++)
            {
                Console.WriteLine("| {0,3} | {1,6} |", i, GradientSpysk.GetMin(f, new X(i, f), 0.5, 0.001));
            }

            Console.WriteLine(new String('-', 16));
            Console.ReadKey();
        }
    }
}
