using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class MinStart
    {
        /*
         Given an array of integers nums, you start with an initial positive value startValue.

        In each iteration, you calculate the step by step sum of startValue plus elements in nums (from left to right).

        Return the minimum positive value of startValue such that the step by step sum is never less than 1.*/
        public int MinStartValue(int[] nums)
        {
            int result = 1;
            int startValue = result;
            int minValue = result;
            for (int i = 0; i < nums.Length; i++)
            {
                startValue += nums[i];
                if (startValue < minValue)
                    minValue = startValue;
            }
            return Math.Max(1, 2 - minValue);
        }
    }
}
