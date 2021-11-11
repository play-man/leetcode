using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    internal class BinaryTree
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            return DiameterAndHeight(root).Item1;
        }
        public Tuple<int, int> DiameterAndHeight(TreeNode root)
        {
            if (root == null) return new Tuple<int, int>(0, 0);

            Tuple<int, int> lhd = DiameterAndHeight(root.left);
            Tuple<int, int> rhd = DiameterAndHeight(root.right);

            return new Tuple<int, int>(
                Math.Max(lhd.Item2, rhd.Item2) + 1,
                Math.Max(Math.Max(lhd.Item1, rhd.Item1), lhd.Item2 + rhd.Item2));
        }
    }
}
