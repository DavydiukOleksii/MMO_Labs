using System;
using Progect.Metods;

namespace Progect
{
    class Program
    {
        static void Main(string[] args)
        {
            HalfDivision half = new HalfDivision(0.6, 3.6, 0.01, "max");
            half.Calculate();

            Dihotomii diho = new Dihotomii(0.6, 3.6, 0.01, "max");
            diho.Calculate();

            GoldCut goldCut = new GoldCut(0.6, 3.6, 0.01, "max");
            goldCut.Calculate();

            Fibonachi fibon = new Fibonachi(0.6, 3.6, 0.01, "max");
            fibon.Calculate();

            Console.Read();
        }
    }
}
