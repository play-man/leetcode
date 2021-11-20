using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class SingleNumberIII
    {
        /*Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. 
        Find the two elements that appear only once. You can return the answer in any order.
        You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
        
        Constraints:

        2 <= nums.length <= 3 * 10^4
        -2^31 <= nums[i] <= 2^31 - 1
        Each integer in nums will appear twice, only two integers will appear once.*/
        public int[] SingleNumber(int[] nums)
        {
            if (nums.Length == 2) return nums;
            // We will first identify with 
            // Twi identical numbers are supposed to be eliminated during XOR, so we are left with a^b, where a and b - desired result
            int xor = 0;
            for (int i = 0; i < nums.Length; i++)
                xor ^= nums[i];

            // Find the position of xor bit which is equal to 1
            // Since a != b, they have at least 1 different bit
            int pos = 0;
            int xorCopy = xor;
            while ((xorCopy != 0) && (xorCopy % 2) == 0)
            {
                xorCopy /= 2;
                pos++;
            }

            // xor0 will go through all numbers which have pos-th bit as 0, and will result in a (or b)
            // xor1 will go through all numbers which have pos-th bit as 1, and will result in b (or a)
            int xor0 = 0, xor1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] >> pos) % 2 == 0)
                    xor0 ^= nums[i];
                else
                    xor1 ^= nums[i];
            }
            return new int[] { xor0, xor1 };
        }
    }
}
