using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class SingleElement
    {
        /*You are given a sorted array consisting of only integers where every element appears exactly twice, 
        except for one element which appears exactly once.
        Return the single element that appears only once.
        Your solution must run in O(log n) time and O(1) space.
         */
        public static int SingleNonDuplicate(int[] nums)
        {
            return SingleNonDuplicateHelper(nums, 0, nums.Length - 1);
        }
        public static int SingleNonDuplicateHelper(int[] nums, int a, int b)
        {
            if ((nums.Length == 1) || (a == b))
                return nums[a];
            // Getting even number around the middle of the array
            int middle = ((b + a) / 2) / 2 * 2;
            // If the number with even index is equal to the next item with odd index
            // it means unique number isn't in the array [0, middle] 
            if (nums[middle] != nums[middle + 1])
                return SingleNonDuplicateHelper(nums, a, middle);
            else
                return SingleNonDuplicateHelper(nums, middle + 2, b);
        }
    }
}
