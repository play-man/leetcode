using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class BalanceTree
    {
        public TreeNode BalanceBST(TreeNode root)
        {
            // Convert BST to linked list
            ListNode list = BSTIntoList.BSTToList(root);
            // Convert linked list into balance tree
            return SortedListIntoBST.SortedListToBST(list);
        }
    }
}
