using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function
{
    public static class Function
    {
        public static double func(X x)
        {
            return Math.Pow((x.x1 - 2), 2) + Math.Pow((x.x2 - 4), 2);
        }
    }
}
