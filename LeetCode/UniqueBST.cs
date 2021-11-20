using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class UniqueBST
    {
        /*Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes of unique values from 1 to n.
        
        Constraints:

        1 <= n <= 19*/
        public int NumTrees(int n)
        {
            // the result is C(n) - n-th Catalan number.
            // Below it's calculated considering possible overflow
            if (n == 1) return 1;
            int prev = NumTrees(n - 1);
            return (prev / (n + 1)) * 2 * (2 * n - 1) + ((prev % (n + 1)) * 2 * (2 * n - 1)) / (n + 1);
        }
    }
}
