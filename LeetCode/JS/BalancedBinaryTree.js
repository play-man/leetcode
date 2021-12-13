/*
Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as:

a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

Constraints:

The number of nodes in the tree is in the range [0, 5000].
-10^4 <= Node.val <= 10^4
 */

var isBalanced = function (root) {
    return isBalancedHelper(root)[0]
};

var isBalancedHelper = function (root) {
    if (root == null)
        return [true, 0]

    let leftRes = isBalancedHelper(root.left)
    let rightRes = isBalancedHelper(root.right)
    return [leftRes[0] && rightRes[0] && (Math.abs(leftRes[1] - rightRes[1]) <= 1), Math.max(leftRes[1], rightRes[1]) + 1]
}