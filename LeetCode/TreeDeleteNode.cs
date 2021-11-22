using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class TreeDeleteNode
    {
        /*
         Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

        Basically, the deletion can be divided into two stages:

        Search for a node to remove.
        If the node is found, delete the node.
        
        Constraints:

        The number of nodes in the tree is in the range [0, 10^4].
        -10^5 <= Node.val <= 10^5
        Each node has a unique value.
        root is a valid binary search tree.
        -10^5 <= key <= 10^5*/
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            TreeNode prev = null;
            TreeNode curr = root;
            // currPrev = -1 => curr is the left child of prev
            // currPrev = 1 => curr is the right child of prev
            int currPrev = 0;

            while (curr != null)
            {
                if (curr.val == key)
                    break;
                else if (curr.val < key)
                {
                    prev = curr;
                    curr = curr.right;
                    currPrev = 1;
                }
                else
                {
                    prev = curr;
                    curr = curr.left;
                    currPrev = -1;
                }
            }
            if (curr == null)
                return root;
            else
            {
                if (curr == root)
                {
                    if (curr.right == null)
                        return curr.left;
                    else if (curr.left == null)
                        return curr.right;
                    else
                    {
                        TreeNode currRightLeftmost = curr.right;
                        while (currRightLeftmost.left != null)
                            currRightLeftmost = currRightLeftmost.left;
                        currRightLeftmost.left = curr.left;
                        return curr.right;
                    }
                }
                else
                {
                    if (curr.right == null)
                    {
                        if (currPrev == -1)
                            prev.left = curr.left;
                        else
                            prev.right = curr.left;
                    }
                    else if (curr.left == null)
                    {
                        if (currPrev == -1)
                            prev.left = curr.right;
                        else
                            prev.right = curr.right;
                    }
                    else
                    {
                        TreeNode currRightLeftmost = curr.right;
                        while (currRightLeftmost.left != null)
                            currRightLeftmost = currRightLeftmost.left;
                        currRightLeftmost.left = curr.left;

                        if (currPrev == -1)
                            prev.left = curr.right;
                        else
                            prev.right = curr.right;
                    }
                    return root;
                }
            }
        }
    }
}
