using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class RangeSum
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            int result = 0;
            RangeSumBSTHelper(root, low, high, ref result);
            return result;
        }

        public void RangeSumBSTHelper(TreeNode root, int low, int high, ref int result)
        {
            if (root == null)
                return;
            if (low <= root.val && high >= root.val)
                result += root.val;
            if (low < root.val)
            {
                RangeSumBSTHelper(root.left, low, high, ref result);
            }
            if (high > root.val)
            {
                RangeSumBSTHelper(root.right, low, high, ref result);
            }
        }
    }
}
