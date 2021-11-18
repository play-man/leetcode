using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*Given an array nums of n integers where nums[i] is in the range [1, n], 
     * return an array of all the integers in the range [1, n] that do not appear in nums.
     
     Constraints:

    n == nums.length
    1 <= n <= 10^5
    1 <= nums[i] <= n*/
    internal static class NumbersDisappeared
    {
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> numsHashSet = Enumerable.Range(1, nums.Length).ToHashSet();

            for (int i = 0; i < nums.Length; i++)
                numsHashSet.Remove(nums[i]);

            return numsHashSet.ToList();
        }
    }
}
