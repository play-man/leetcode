using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class ThreeSum
    {
        public static IList<IList<int>> ThreeSumFunction(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length >= 3)
            {
                List<int> numsSorted = SortAndRemoveNonzeroDuplicates(new List<int>(nums));
                Console.WriteLine(String.Join(",", numsSorted));
                int firstNegativeIndex = -1;
                int firstZeroIndex = -1;
                int firstPositiveIndex = -1;
                int lastNegativeIndex = -1;
                int lastZeroIndex = -1;
                int lastPositiveIndex = -1;
                for (int i = 0; i < numsSorted.Count; ++i)
                {
                    if (numsSorted[i] < 0)
                    {
                        lastNegativeIndex = i;
                        if (firstNegativeIndex < 0)
                            firstNegativeIndex = i;
                    }
                    else if (numsSorted[i] == 0)
                    {
                        lastZeroIndex = i;
                        if (firstZeroIndex < 0)
                            firstZeroIndex = i;
                    }
                    else if (numsSorted[i] > 0)
                    {
                        lastPositiveIndex = i;
                        if (firstPositiveIndex < 0)
                            firstPositiveIndex = i;
                    }
                }

                if (lastZeroIndex - lastNegativeIndex >= 3)
                    result.Add(new List<int> { 0, 0, 0 });

                if ((lastNegativeIndex >= 0) && (lastPositiveIndex >= 0))
                {
                    if ((lastZeroIndex - lastNegativeIndex >= 1))
                    {
                        for (int i = 0; i <= lastNegativeIndex; ++i)
                        {
                            for (int j = firstPositiveIndex; j <= lastPositiveIndex; ++j)
                                if (numsSorted[i] + numsSorted[j] == 0)
                                    result.Add(new List<int> { numsSorted[i], 0, numsSorted[j] });
                        }
                    }

                    for (int i = 0; i <= lastNegativeIndex; ++i)
                    {
                        List<List<int>> positiveTargetTriples = TwoSumSortedPositiveTarget(numsSorted, -numsSorted[i], firstPositiveIndex);
                        for (int j = 0; j < positiveTargetTriples.Count; ++j)
                            result.Add(positiveTargetTriples[j]);
                    }
                    for (int i = firstPositiveIndex; i <= lastPositiveIndex; ++i)
                    {
                        List<List<int>> negativeTargetTriples = TwoSumSortedNegativeTarget(numsSorted, -numsSorted[i], lastNegativeIndex);
                        for (int j = 0; j < negativeTargetTriples.Count; ++j)
                            result.Add(negativeTargetTriples[j]);
                    }
                }
            }
            return result;
        }

        public static List<List<int>> TwoSumSortedPositiveTarget(List<int> nums, int target, int firstPositiveIndex)
        {
            List<List<int>> result = new List<List<int>>();
            int x = firstPositiveIndex;
            int y = nums.Count - 1;
            while (x < y)
            {
                if (nums[x] + nums[y] == target)
                {
                    result.Add(new List<int> { -target, nums[x], nums[y] });
                }
                else if (nums[x] + nums[y] < target)
                {
                    x++;
                }
                else if (nums[x] + nums[y] > target)
                {
                    y--;
                }
            }
            return result;
        }

        public static List<List<int>> TwoSumSortedNegativeTarget(List<int> nums, int target, int lastNegativeIndex)
        {
            List<List<int>> result = new List<List<int>>();
            int x = 0;
            int y = lastNegativeIndex;
            while (x < y)
            {
                if (nums[x] + nums[y] == target)
                {
                    result.Add(new List<int> { nums[x], nums[y], -target });
                }
                else if (nums[x] + nums[y] < target)
                {
                    x++;
                }
                else if (nums[x] + nums[y] > target)
                {
                    y--;
                }
            }
            return result;
        }

        public static List<int> SortAndRemoveNonzeroDuplicates(List<int> nums)
        {
            if (nums.Count <= 1)
                return nums;
            else
            {
                List<int> numsSorted = new List<int>();
                int middleIndex = nums.Count / 2;
                int middle = nums[middleIndex];
                List<int> lower = new List<int>();
                List<int> greater = new List<int>();
                for (int i = 0; i < middleIndex; ++i)
                {
                    if (nums[i] < middle)
                    {
                        lower.Add(nums[i]);
                    }
                    else if ((nums[i] > middle) || (middle == 0))
                    {
                        greater.Add(nums[i]);
                    }
                }
                for (int i = middleIndex + 1; i < nums.Count; ++i)
                {
                    if (nums[i] < middle)
                    {
                        lower.Add(nums[i]);
                    }
                    else if ((nums[i] > middle) || (middle == 0))
                    {
                        greater.Add(nums[i]);
                    }
                }
                numsSorted.AddRange(SortAndRemoveNonzeroDuplicates(lower));
                numsSorted.Add(middle);
                numsSorted.AddRange(SortAndRemoveNonzeroDuplicates(greater));
                return numsSorted;
            }
        }
    }
}
