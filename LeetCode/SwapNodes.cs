using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class SwapNodes
    {
        /*Given a linked list, swap every two adjacent nodes and return its head. 
         *You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)*/
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode result;
            if ((head == null) || (head.next == null))
                return head;
            else
            {
                ListNode prev = null;
                ListNode curr = head;
                ListNode next = head.next;
                result = next;
                while (curr != null && next != null)
                {
                    if (prev != null)
                        prev.next = next;
                    curr.next = next.next;
                    next.next = curr;
                    prev = curr;
                    next = curr != null && curr.next != null ? curr.next.next : null;
                    curr = curr != null ? curr.next : null;
                }
            }
            return result;
        }
    }
}
