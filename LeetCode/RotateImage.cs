using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

    You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. 
    DO NOT allocate another 2D matrix and do the rotation.
    Constraints:

    matrix.length == n
    matrix[i].length == n
    1 <= n <= 20
    -1000 <= matrix[i][j] <= 1000*/
    internal static class RotateImage
    {
        public static int[][] Rotate(int[][] matrix)
        {
            // Select top quarter of image, and for each cell in it, rotate 4 cells
            // (including the selected one) symmetric with respect to 
            // vertical and horizontal axis, and the center of a square

            // If matrix size is odd, middle square doesn't need to be rotated
            int size = matrix.Length;
            int m = size / 2;
            int n = size % 2 == 0 ? size / 2 : size / 2 + 1;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    int x = matrix[i][j];
                    matrix[i][j] = matrix[j][size - 1 - i];
                    matrix[j][size - 1 - i] = x;

                    x = matrix[size - 1 - j][i];
                    matrix[size - 1 - j][i] = matrix[size - 1 - i][size - 1 - j];
                    matrix[size - 1 - i][size - 1 - j] = x;

                    x = matrix[i][j];
                    matrix[i][j] = matrix[size - 1 - i][size - 1 - j];
                    matrix[size - 1 - i][size - 1 - j] = x;
                }
            return matrix;
        }
    }
}
