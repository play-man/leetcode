using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

    1. BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. 
    The root of the BST is given as part of the constructor. 
    The pointer should be initialized to a non-existent number smaller than any element in the BST.
    2. boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
    3. int next() Moves the pointer to the right, then returns the number at the pointer.
    
    Notice that by initializing the pointer to a non-existent smallest number, 
    the first call to next() will return the smallest element in the BST.

    You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.
    
    Constraints:

    The number of nodes in the tree is in the range [1, 10^5].
    0 <= Node.val <= 10^6
    At most 10^5 calls will be made to hasNext, and next.*/
    internal class BSTIterator
    {
        TreeNode root;
        int currentVal;
        int highestVal;
        Stack<TreeNode> stack;
        public BSTIterator(TreeNode root)
        {
            this.root = root;
            this.currentVal = -1;
            this.highestVal = Rightmost(root).val;
            stack = new Stack<TreeNode>();
            FillStackInitial(root);
        }

        public int Next()
        {
            TreeNode current = stack.Peek();

            if (currentVal < 0)
            {
                currentVal = current.val;
                return current.val;
            }

            if (current.right != null)
            {
                // Move to the right 
                current = current.right;
                stack.Push(current);
                // And all the way to the left
                while (current.left != null)
                {
                    current = current.left;
                    stack.Push(current);
                }
            }
            else
            {
                current = stack.Pop();
                // Move up all the way up by the right branch, and up to the left
                while (stack.Count > 1 && current.val > stack.Peek().val)
                    current = stack.Pop();
            }
            current = stack.Peek();
            currentVal = current.val;
            return currentVal;
        }

        public void FillStackInitial(TreeNode node)
        {
            stack.Push(node);
            if (node.left != null)
            {
                FillStackInitial(node.left);
            };
        }

        public TreeNode Leftmost(TreeNode node)
        {
            return (node.left != null) ? Leftmost(node.left) : node;
        }

        public TreeNode Rightmost(TreeNode node)
        {
            return (node.right != null) ? Rightmost(node.right) : node;
        }

        public bool HasNext()
        {
            return currentVal != highestVal;
        }
    }
}
