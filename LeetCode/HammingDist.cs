using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class HammingDist
    {
        /*
         The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

        Given two integers x and y, return the Hamming distance between them.*/
        public static int HammingDistance(int x, int y)
        {
            if ((x == 0) && (y == 0)) return 0;
            int result = x % 2 == y % 2 ? 0 : 1;
            return result + HammingDistance(x/2, y/2);
        }
    }
}
