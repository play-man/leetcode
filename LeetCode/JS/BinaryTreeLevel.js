/*
Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Constraints:

The number of nodes in the tree is in the range [0, 2000].
-1000 <= Node.val <= 1000
 */

var levelOrder = function (root) {
    if (!root) return []
    let queue = [[root, 0]]
    let result = []
    let current = undefined
    while (queue.length > 0) {
        current = queue[queue.length - 1]
        if (result[current[1]])
            result[current[1]].push(current[0].val)
        else
            result[current[1]] = [current[0].val]

        if (current[0].left)
            queue.unshift([current[0].left, current[1] + 1])
        if (current[0].right)
            queue.unshift([current[0].right, current[1] + 1])
        queue.pop();
    }
    return result
};