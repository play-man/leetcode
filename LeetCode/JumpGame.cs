using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class JumpGame
    {
        public static int Jump(int[] nums)
        {
            int result = 0;
            int pos = 0; // Current position before next jump
            // Jump into the highest number possible until reaching the end, which is presumably possible
            while (pos < nums.Length - 1)
            {
                int rightBound = Math.Min(nums.Length - 1, pos + nums[pos]);
                int nextPos = pos;
                // Capacity resembles a potential of next position, considering it's index and value
                // It is inversed, being subtracted from the index of last element in array
                int nextPosCapacity = nums.Length - 1 - pos - nums[pos];
                if (nextPosCapacity <= 0)
                {
                    result++;
                    break;
                }
                else
                {
                    for (int i = pos + 1; i <= rightBound; ++i)
                    {
                        int posCapacity = nums.Length - 1 - i - nums[i];
                        if (posCapacity <= nextPosCapacity)
                        {
                            nextPosCapacity = posCapacity;
                            nextPos = i;
                        }
                    }
                    pos = nextPos;
                    result++;
                }
            }
            return result;
        }
    }
}
