using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { -1, 0, 1, 2, -1, -4 };
            int[] nums2 = new int[] { -1, 0, 1, 2, -1, -4 };
            //Console.WriteLine((new MedianTwoArrays()).FindMedianSortedArrays(nums1, nums2));
            //Console.WriteLine((new Atoi().MyAtoi("-5.-")));
            //Console.WriteLine(LeapYears.MonthCount(new DateTime(1901, 1, 1), new DateTime(1999, 12, 1), 1, 2));
            //Console.WriteLine(StockSeller.MaxProfit(new int[] { 3, 1, 2, 6, 3, 4, 6 }));
            //Console.WriteLine(StockSellerIII.MaxProfit(new int[] { 14, 9, 10, 12, 4, 8, 1, 16 }));
            //Console.WriteLine(LongestPalindromeClass.LongestPalindrome("abbbbbbbbbba"));
            /*Console.WriteLine(MinHeight.FindMinHeightTrees(6, new int[][] {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 0, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
            })[0]);*/
            Console.WriteLine(Divisors.GCD(-5, -3));
            Console.ReadKey();
        }
    }
}
