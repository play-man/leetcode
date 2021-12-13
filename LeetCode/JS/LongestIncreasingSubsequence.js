/*
Given an integer array nums, return the length of the longest strictly increasing subsequence.

A subsequence is a sequence that can be derived from an array by deleting some or no elements without changing the order of the remaining elements. 
For example, [3,6,2,7] is a subsequence of the array [0,3,1,6,2,2,7].

Constraints:

1 <= nums.length <= 2500
-10^4 <= nums[i] <= 10^4
 */

var lengthOfLIS = function (nums) {
    let sequenceLength = new Array(nums.length).fill(1)
    let max = 1
    let i = 0
    let j = 0

    for (i = 0; i < nums.length; ++i) {
        for (j = i - 1; j >= 0; --j) {
            if (nums[j] < nums[i]) {
                if (sequenceLength[j] + 1 > sequenceLength[i])
                    sequenceLength[i] = sequenceLength[j] + 1
            }
        }
        if (sequenceLength[i] > max)
            max = sequenceLength[i]
    }

    return max
};