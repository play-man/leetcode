using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). 
    n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). 
    Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

    Notice that you may not slant the container.

    Constraints:

    n == height.length
    2 <= n <= 10^5
    0 <= height[i] <= 10^4
    */
    internal static class WaterContainer
    {
        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            int currentLeftPos = 0;
            int currentRightPos = height.Length - 1;
            while (currentLeftPos < currentRightPos)
            {
                int currentSize = Math.Min(height[currentRightPos], height[currentLeftPos]) * (currentRightPos - currentLeftPos);
                if (currentSize > maxArea)
                    maxArea = currentSize;

                if (height[currentLeftPos] < height[currentRightPos])
                    currentLeftPos++;
                else
                    currentRightPos--;
            }
            return maxArea;
        }
    }
}
