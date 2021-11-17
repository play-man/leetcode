using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

    The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

    How many possible unique paths are there?
    
    Constraints:

    1 <= m, n <= 100
    It's guaranteed that the answer will be less than or equal to 2 * 10^9.*/
    internal static class UniquePath
    {
        public static int UniquePathsRecursive(int m, int n)
        {
            int mMax = Math.Min(m, n);
            int nMin = Math.Max(m, n);
            Dictionary<Tuple<int, int>, int> uniquePathsCalculated = new Dictionary<Tuple<int, int>, int>();
            return UniquePathsHelper(uniquePathsCalculated, mMax, nMin);
        }
        public static long UniquePathsBinomial(int m, int n)
        {
            return BinomialCoeff(m + n - 2, m - 1);
        }
        public static int UniquePathsHelper(Dictionary<Tuple<int, int>, int> uniquePathsCalculated, int m, int n)
        {
            if ((m == 1) || (n == 1)) return 1;
            else
            {
                Tuple<int, int> t1 = new Tuple<int, int>(m, n);
                Tuple<int, int> t2 = new Tuple<int, int>(n, m);
                if (uniquePathsCalculated.ContainsKey(t1))
                    return uniquePathsCalculated[t1];
                else if (uniquePathsCalculated.ContainsKey(t2))
                    return uniquePathsCalculated[t2];
                else
                {
                    int result = 0;
                    for (int i = 1; i <= n; ++i)
                    {
                        Tuple<int, int> iTuple1 = new Tuple<int, int>(m - 1, i);
                        Tuple<int, int> iTuple2 = new Tuple<int, int>(i, m - 1);
                        int iResult;
                        if (uniquePathsCalculated.ContainsKey(iTuple1))
                        {
                            iResult = uniquePathsCalculated[iTuple1];
                        }
                        else if (uniquePathsCalculated.ContainsKey(iTuple2))
                        {
                            iResult = uniquePathsCalculated[iTuple2];
                        }
                        else
                        {
                            iResult = UniquePathsHelper(uniquePathsCalculated, m - 1, i);
                            uniquePathsCalculated.Add(iTuple1, iResult);
                        }
                        result += iResult;
                    }
                    return result;
                }
            }
        }

        public static long BinomialCoeff(int n, int k)
        {
            // For lower values guaranteed by constraints, this method proves well
            long result = 1;
            int divisor;
            if (k > n) return 0;
            for (divisor = 1; divisor <= k; divisor++)
            {
                result *= n--;
                result /= divisor;
            }
            return result;
        }
    }
}
