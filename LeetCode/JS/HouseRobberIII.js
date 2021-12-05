/*
The thief has found himself a new place for his thievery again. There is only one entrance to this area, called root.

Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that all houses in this place form a binary tree. It will automatically contact the police if two directly-linked houses were broken into on the same night.

Given the root of the binary tree, return the maximum amount of money the thief can rob without alerting the police.

Constraints:

The number of nodes in the tree is in the range [1, 10^4].
0 <= Node.val <= 10^4
 */

var rob = function (root) {
    robHelper(root)
    return root.robAmount
};

var robHelper = function (root) {
    if (!root)
        return
    if (!root.left && !root.right) {
        root.robAmount = root.val
        return
    }
    robHelper(root.left)
    robHelper(root.right)
    root.robAmount = Math.max(root.val + (root.left ? ((root.left.left ? root.left.left.robAmount : 0) + (root.left.right ? root.left.right.robAmount : 0)) : 0) + (root.right ? ((root.right.left ? root.right.left.robAmount : 0) + (root.right.right ? root.right.right.robAmount : 0)) : 0), (root.left ? root.left.robAmount : 0) + (root.right ? root.right.robAmount : 0))
};
