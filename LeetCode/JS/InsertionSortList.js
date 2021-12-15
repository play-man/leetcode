/*
Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.

The steps of the insertion sort algorithm:

Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
It repeats until no input elements remain.
The following is a graphical example of the insertion sort algorithm. The partially sorted list (black) initially contains only the first element in the list. 
One element (red) is removed from the input data and inserted in-place into the sorted list with each iteration.

*/

var insertionSortList = function (head) {
    if (!head.next) return head

    let result = head
    let curr = head.next
    let currNext = head.next.next
    let insertBefore = head
    let insertBeforePrev = null

    result.next = null

    while (curr) {
        insertBeforePrev = null
        insertBefore = result
        while (insertBefore && insertBefore.val <= curr.val) {
            insertBeforePrev = insertBefore
            insertBefore = insertBefore.next
        }
        if (insertBeforePrev) {
            insertBeforePrev.next = curr
            curr.next = insertBefore
        }
        else {
            curr.next = insertBefore
            result = curr
        }
        curr = currNext
        currNext = curr ? curr.next : null
    }

    return result
};