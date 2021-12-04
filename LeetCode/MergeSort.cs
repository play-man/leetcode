using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class MergeSort
    {
        internal static void Sort(double[] arr)
        {
            SortHelper(arr, 0, arr.Length - 1);
        }
        internal static void SortHelper(double[] arr, int start, int end)
        {
            if (start == end) return;
            int middle = (start + end)/ 2;
            SortHelper(arr, start, middle);
            SortHelper(arr, middle + 1, end);
            MergeTwoHalfs(arr, start, end, middle);
        }

        internal static void MergeTwoHalfs(double[] arr, int start, int end, int middle)
        {
            int reorderCurrent = middle;
            double temp = 0;
            while (reorderCurrent >= start)
            {
                int toSwap = reorderCurrent + 1;
                while (toSwap <= end)
                {
                    if (arr[reorderCurrent] < arr[toSwap])
                    {
                        temp = arr[reorderCurrent];
                        arr[reorderCurrent] = arr[toSwap - 1];
                        arr[toSwap - 1] = temp;
                        break;
                    }
                    else
                        toSwap++;
                }
                if (toSwap == end + 1)
                {
                    int tempIndex = reorderCurrent;
                    while (tempIndex < end)
                    {
                        temp = arr[tempIndex];
                        arr[tempIndex] = arr[tempIndex + 1];
                        arr[tempIndex + 1] = temp;
                        tempIndex++;
                    }
                }
                reorderCurrent--;
            }
        }
    }
}
