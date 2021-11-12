using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class FirstLastPosition
    {
        /*Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
        If target is not found in the array, return [-1, -1].
        You must write an algorithm with O(log n) runtime complexity.*/
        public static int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1};

            if (nums.Length > 0)
            {
                // Binary search: to find 
                int leftBoundLeft = 0;
                int rightBoundLeft = nums.Length - 1;
                while (leftBoundLeft <= rightBoundLeft)
                {
                    int n = leftBoundLeft + (rightBoundLeft - leftBoundLeft) / 2;
                    if (nums[n] > target)
                    {
                        rightBoundLeft = n - 1;
                    }
                    else if (nums[n] < target)
                    {
                        leftBoundLeft = n + 1;
                    }
                    else
                    {
                        result[0] = n;
                        rightBoundLeft = n - 1;
                    }
                }

                if (result[0] >= 0)
                {
                    int leftBoundRight = 0;
                    int rightBoundRight = nums.Length - 1;
                    while (leftBoundRight <= rightBoundRight)
                    {
                        int n = leftBoundRight + (rightBoundRight - leftBoundRight) / 2;
                        if (nums[n] > target)
                        {
                            rightBoundRight = n - 1;
                        }
                        else if (nums[n] < target)
                        {
                            leftBoundRight = n + 1;
                        }
                        else
                        {
                            result[1] = n;
                            leftBoundRight = n + 1;
                        }
                    }
                }
            }
            return result;
        }
    }
}
