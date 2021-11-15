using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class LargestDivisibleSub
    {
        /*
        Given a set of distinct positive integers nums, return the largest subset answer such that every pair (answer[i], answer[j]) of elements in this subset satisfies:

        answer[i] % answer[j] == 0, or
        answer[j] % answer[i] == 0
        If there are multiple solutions, return any of them.

        Constraints:

        1 <= nums.length <= 1000
        1 <= nums[i] <= 2 * 10^9
        All the integers in nums are unique. 
         */
        public static IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums.Length == 1) return new List<int>(nums);

            List<int> result = new List<int>();
            List<int> numsSorted = new List<int>(nums);
            // A list which refers to the previous element in sequence. Initial values are -1
            List<int> greatestPreceedingDivisor = new List<int>();
            // A list which defines the length of sequence ending at respective index. Initial values are 1
            List<int> sequenceLength = new List<int>();

            int maxLengthIndex = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                greatestPreceedingDivisor.Add(-1);
                sequenceLength.Add(1);
            }

            numsSorted.Sort();

            // Looking for all subsets ending at i
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numsSorted[i] % numsSorted[j] == 0)
                    {
                        if (sequenceLength[j] + 1 > sequenceLength[i])
                        {
                            sequenceLength[i] = sequenceLength[j] + 1;
                            greatestPreceedingDivisor[i] = j;
                        }
                    }
                }
                if (sequenceLength[maxLengthIndex] < sequenceLength[i])
                    maxLengthIndex = i;
            }

            int maxLength = sequenceLength[maxLengthIndex];
            for (int i = 0; i < maxLength; ++i)
            {
                result.Add(numsSorted[maxLengthIndex]);
                maxLengthIndex = greatestPreceedingDivisor[maxLengthIndex];
            }
            result.Reverse();
            return result;
        }
    }
}
