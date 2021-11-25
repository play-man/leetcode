/*
 Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.

Constraints:

The number of nodes in the tree is in the range [1, 10^4].
-2^31 <= Node.val <= 2^31 - 1
 */

var isValidBST = function (root) {
    return treeToLinkedList(root)[1]
};

function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}

function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

var treeToLinkedList = function (root) {
    let resultvalid = true;
    if (root === null)
        return [null, true]
    let leftresult = treeToLinkedList(root.left);
    let rightresult = treeToLinkedList(root.right);

    let leftstart = leftresult[0]
    let rightstart = rightresult[0]
    let leftvalid = leftresult[1]
    let rightvalid = rightresult[1]

    let middle = new ListNode(root.val, rightstart)
    if (rightstart !== null && (middle.val >= rightstart.val))
        resultvalid = false

    let leftend = leftstart

    if (leftstart !== null) {
        while (leftend.next !== null)
            leftend = leftend.next
        leftend.next = middle

        if (leftend.val >= middle.val)
            resultvalid = false
    }

    return [leftstart !== null ? leftstart : middle, leftvalid && rightvalid && resultvalid]
}
