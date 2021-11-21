using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class SortedListIntoBST
    {
        /*Given the head of a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

        For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        
        Constraints:

        The number of nodes in head is in the range [0, 2 * 10^4].
        -10^5 <= Node.val <= 10^5*/
        public static TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null)
            {
                return new TreeNode(head.val);
            }
            if (head.next.next == null)
            {
                return new TreeNode(head.next.val, new TreeNode(head.val));
            }
            // Split list into two halfs
            ListNode middle = ListMiddle(head);
            TreeNode treeHead = new TreeNode(middle.val);
            ListNode leftListCurrent = head;
            ListNode rightListHead = middle.next;
            while (leftListCurrent.next != middle)
            {
                leftListCurrent = leftListCurrent.next;
            }
            // When we reach middle of the list, throw away remainder
            leftListCurrent.next = null;
            middle.next = null;
            treeHead.left = SortedListToBST(head);
            treeHead.right = SortedListToBST(rightListHead);
            return treeHead;
        }

        public static ListNode ListMiddle(ListNode head)
        {
            ListNode current = head;
            ListNode current2x = head;
            while (current2x != null && current2x.next != null)
            {
                current = current.next;
                current2x = current2x.next.next;
            }
            return current;
        }
    }
}
