using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class BTInorderPostorder
    {
        /*
         Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree 
        and postorder is the postorder traversal of the same tree, construct and return the binary tree.
        
        Constraints:

        1 <= inorder.length <= 3000
        postorder.length == inorder.length
        -3000 <= inorder[i], postorder[i] <= 3000
        inorder and postorder consist of unique values.
        Each value of postorder also appears in inorder.
        inorder is guaranteed to be the inorder traversal of the tree.
        postorder is guaranteed to be the postorder traversal of the tree.*/
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTreeHelper(new List<int>(inorder), new List<int>(postorder), postorder.Length - 1);
        }
        public TreeNode BuildTreeHelper(List<int> inorder, List<int> postorder, int rootPostorderIndex)
        {
            TreeNode root = new TreeNode(postorder[rootPostorderIndex], null, null);

            int rootInorderIndex = inorder.IndexOf(postorder[rootPostorderIndex]);

            // Find left child of root
            int leftChildPostorderIndex = rootPostorderIndex;
            while ((leftChildPostorderIndex >= 0) && (rootInorderIndex <= inorder.IndexOf(postorder[leftChildPostorderIndex])))
                leftChildPostorderIndex--;
            // Find right child of root
            int rightChildPostorderIndex = rootPostorderIndex;
            while ((rightChildPostorderIndex >= 0) && (rootInorderIndex >= inorder.IndexOf(postorder[rightChildPostorderIndex])))
                rightChildPostorderIndex--;

            List<int> newInorderLeft = inorder.GetRange(0, rootInorderIndex);
            List<int> newInorderRight = inorder.GetRange(rootInorderIndex, inorder.Count - rootInorderIndex);
            newInorderRight.RemoveAt(0);
            List<int> newPostorderLeft = postorder.Where(x => newInorderLeft.Contains(x)).ToList();
            List<int> newPostorderRight = postorder.Where(x => newInorderRight.Contains(x)).ToList();

            root.left = leftChildPostorderIndex >= 0 ? BuildTreeHelper(newInorderLeft, newPostorderLeft, newPostorderLeft.IndexOf(postorder[leftChildPostorderIndex])) : null;
            root.right = rightChildPostorderIndex >= 0 ? BuildTreeHelper(newInorderRight, newPostorderRight, newPostorderRight.IndexOf(postorder[rightChildPostorderIndex])) : null;

            return root;
        }
    }
}
