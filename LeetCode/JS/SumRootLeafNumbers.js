/*
You are given the root of a binary tree containing digits from 0 to 9 only.

Each root-to-leaf path in the tree represents a number.

For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
Return the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will fit in a 32-bit integer.

A leaf node is a node with no children.

Constraints:

The number of nodes in the tree is in the range [1, 1000].
0 <= Node.val <= 9
The depth of the tree will not exceed 10.
 */

var sumNumbers = function (root) {
    let result = 0
    root.base = 0

    var sumNumbersHelper = function (root) {
        if (!root.right && !root.left)
            result += 10 * root.base + root.val
        if (root.left) {
            root.left.base = 10 * root.base + root.val
            sumNumbersHelper(root.left)
        }
        if (root.right) {
            root.right.base = 10 * root.base + root.val
            sumNumbersHelper(root.right)
        }
    };

    sumNumbersHelper(root)

    return result
};