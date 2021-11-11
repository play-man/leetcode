using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*class MedianTwoArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            return (FindLowerMedianSortedArrays(nums1, nums2, 0, nums1.Length - 1, 0, nums2.Length - 1) +
                FindHigherMedianSortedArrays(nums1, nums2, 0, nums1.Length - 1, 0, nums2.Length - 1)) / 2;
        }

        public double FindLowerMedianSortedArrays(int[] nums1, int[] nums2, int nums1Start, int nums1End, int nums2Start, int nums2End)
        {
            if (nums1Start == nums1End && nums2Start == nums2End)
            {
                return nums1[nums1Start] > nums2[nums2Start] ? nums1[nums1Start] : nums2[nums2Start];
            }
            else if (((nums1End - nums1Start + 1) % 2 == 0) && ((nums2End - nums2Start + 1) % 2 == 0))
            {
                if (nums1[nums1End] > nums2[nums2End])
                    return FindLowerMedianSortedArrays(nums1, nums2, nums1Start, nums1End, nums2Start, nums2End);
                else
                    return FindLowerMedianSortedArrays(nums1, nums2, nums1Start, nums1End, nums2Start, nums2End);
            }
            else if (((nums1End - nums1Start + 1) % 2 == 0) && ((nums2End - nums2Start + 1) % 2 == 1))
            {

            }
            else if (((nums1End - nums1Start + 1) % 2 == 1) && ((nums2End - nums2Start + 1) % 2 == 0))
            {

            }
            else if (((nums1End - nums1Start + 1) % 2 == 1) && ((nums2End - nums2Start + 1) % 2 == 1))
            {

            }
        }

        public double FindHigherMedianSortedArrays(int[] nums1, int[] nums2, int nums1Start, int nums1End, int nums2Start, int nums2End)
        {
            if (nums1Start == nums1End && nums2Start == nums2End)
            {
                return nums1[nums1Start] > nums2[nums2End] ? nums1[nums1Start] : nums2[nums2End]
            }
            else if ((nums1.Length % 2 == 0) && (nums2.Length % 2 == 0))
            {

            }
            else if ((nums1.Length % 2 == 0) && (nums2.Length % 2 == 0))
            {

            }
            else if ((nums1.Length % 2 == 0) && (nums2.Length % 2 == 0))
            {

            }
            else if ((nums1.Length % 2 == 0) && (nums2.Length % 2 == 0))
            {

            }
        }
    }*/
}
