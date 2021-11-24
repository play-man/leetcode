/*
 Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

A subarray is a contiguous part of an array.

Constraints:

1 <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4


Follow up: If you have figured out the O(n) solution, 
try coding another solution using the divide and conquer approach, which is more subtle.*/

var maxSubArray = function (nums) {
    let result = nums[0];
    let start = 0;
    let end = 0;
    let tailSum = 0;
    let positiveFound = false;
    let minNonPositive = nums[0];

    while ((start < nums.length) && (nums[start] <= 0)) {
        if (nums[start] > minNonPositive)
            minNonPositive = nums[start];
        start++;
    }

    if (start == nums.length)
        return minNonPositive;

    // Positive number reached
    result = nums[start];
    tailSum = nums[start];
    end = start + 1;

    while (end < nums.length) {
        while ((end < nums.length) && (nums[end] < 0)) {
            tailSum += nums[end];
            end++;
        }
        if (end < nums.length) {
            if (tailSum < 0) {
                start = end;
                tailSum = nums[end];
                if (result < tailSum)
                    result = tailSum;
            }
            else {
                tailSum += nums[end];
                if (result < tailSum)
                    result = tailSum;
            }
            end++;
        }
    }
    return result;
};