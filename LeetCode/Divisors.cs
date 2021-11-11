using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class Divisors
    {
        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0) return b;
            else if (b == 0) return a;
            else if (a > b)
                return GCD(b, a - b * (a / b));
            else
                return GCD(a, b - a * (b / a));
        }
    }
}
