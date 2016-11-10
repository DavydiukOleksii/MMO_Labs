using System;
using Function.Methods;

namespace Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tMetod Hyka-Dzivsa");
            Huka_Dzhivsa.Calculete(0.001, 1, 2, 0, 0);
            Console.WriteLine("\n\n\tMetod Pokoordunatnogo spysky");
            CoordinateDown.Calculete(0.001, 1, 2, 0, 0);

            Console.WriteLine("\n\n\tMetod Neldera-Mida");
            //Нелдер і Мід a = 1, b = 0,5, y = 2
            NelderaMida.Calculete(0.001, 1, 0.5, 2, 0, 0);

            Console.Read();
        }
    }
}
