using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class KSmallestNumber
    {
        /*Nearly everyone has used the Multiplication Table. 
        The multiplication table of size m x n is an integer matrix mat where mat[i][j] == i * j (1-indexed).

        Given three integers m, n, and k, return the kth smallest element in the m x n multiplication table.
        
        Constraints:

        1 <= m, n <= 3 * 10^4
        1 <= k <= m * n */
        public static int FindKthNumber(int m, int n, int k)
        {
            int lowerThreshold = 0;
            int upperThreshold = m * n;
            int middle = 0;

            // Applying binary search for the interval [lowerThreshold, upperThreshold].
            // Lower threshold is supposed to get closer to desired answer, but it never would be one
            // Because as it follows from the code
            // NotGreaterThanEqual(m, n, lowerThreshold) < NotGreaterThanEqual(m, n, k) - strictly
            // However, since NotGreaterThanEqual(m, n, upperThreshold) >= NotGreaterThanEqual(m, n, k)
            // upperThreshold would be once we reach: upperThreshold - lowerThreshold = 1
            int currentCount = 0;
            while (upperThreshold - lowerThreshold > 1)
            {
                middle = lowerThreshold + (upperThreshold - lowerThreshold) / 2;
                currentCount = NotGreaterThanEqual(m, n, middle);
                if (currentCount >= k)
                    upperThreshold = middle;
                else
                    lowerThreshold = middle;
            }
            return upperThreshold;
        }

        // Finds the count of numbers in m x n table not greater than input
        public static int NotGreaterThanEqual(int m, int n, int input)
        {
            int result = 0;
            int lastRow = Math.Min(input, m);
            for (int i = 0; i < lastRow; i++)
                result += Math.Min(input / (i + 1), n);
            return result;
        }
    }
}
