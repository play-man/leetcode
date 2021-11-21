using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class BSTIntoList
    {
        public static ListNode BSTToList(TreeNode root)
        {
            if (root == null) return null;

            ListNode leftStart = BSTToList(root.left);
            ListNode rightStart = BSTToList(root.right);
            ListNode middle = new ListNode(root.val, rightStart);
            ListNode leftEnd = leftStart;

            if (leftEnd != null)
            {
                while (leftEnd.next != null)
                    leftEnd = leftEnd.next;
                leftEnd.next = middle;
            }
            return leftStart != null ? leftStart : middle;
        }
    }
}
