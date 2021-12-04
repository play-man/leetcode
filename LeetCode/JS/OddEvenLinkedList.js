/*
Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

The first node is considered odd, and the second node is even, and so on.

Note that the relative order inside both the even and odd groups should remain as it was in the input.

You must solve the problem in O(1) extra space complexity and O(n) time complexity.

Constraints:

n == number of nodes in the linked list
0 <= n <= 10^4
-10^6 <= Node.val <= 10^6
 */

var oddEvenList = function (head) {
    if (!head) return head

    let curr = head
    let next = head.next

    // Maps to the last odd node
    let oddLast = curr
    // Maps to the first even node
    let firstEven = next

    while (curr && next) {
        oddLast = curr
        curr.next = curr.next.next
        if (curr.next) {
            next.next = curr.next.next
            next = next.next
        }
        else
            next = undefined
        curr = curr.next
    }

    // If n is odd, we'll need to update oddLast once again
    if (curr && !next)
        oddLast = curr

    oddLast.next = firstEven

    return head
};