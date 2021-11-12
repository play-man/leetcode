using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    internal class LinkedListRemove
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            if (head != null)
            {
                ListNode prev = head;
                ListNode current = head.next;
                while (current != null)
                {
                    if (current.val == val)
                    {
                        prev.next = current.next;
                    }
                    else
                        prev = prev.next;
                    current = prev.next;
                }
                return head;
            }
            else return null;
        }
    }
}
