using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect
{
    public static class GeneratorFibonachi
    {
        public static IEnumerable<int> GetFibonachi(double endElement) 
        {
            int prev = 0;
            int current = 1;
            do
            {
                yield return current;
                int tmp = current;
                current = prev + current;
                prev = tmp;
            } while (current < endElement);
            yield return current;
        }
    }
}
