/*
Given an integer array nums, return the number of longest increasing subsequences.

Notice that the sequence has to be strictly increasing.

Constraints:

1 <= nums.length <= 2000
-10^6 <= nums[i] <= 10^6
 */

var findNumberOfLIS = function (nums) {
    let sequenceLength = new Array(nums.length).fill(1)
    let numberOfPartialLIS = new Array(nums.length).fill(1)
    let max = 1
    let numberOfLIS = 0
    let i = 0
    let j = 0

    for (i = 0; i < nums.length; ++i) {
        for (j = i - 1; j >= 0; --j) {
            if (nums[j] < nums[i]) {
                if (sequenceLength[j] + 1 === sequenceLength[i])
                    numberOfPartialLIS[i] += numberOfPartialLIS[j]
                else if (sequenceLength[j] + 1 > sequenceLength[i]) {
                    sequenceLength[i] = sequenceLength[j] + 1
                    numberOfPartialLIS[i] = numberOfPartialLIS[j]
                }
            }
        }

        if (sequenceLength[i] === max)
            numberOfLIS += numberOfPartialLIS[i]
        else if (sequenceLength[i] > max) {
            max = sequenceLength[i]
            numberOfLIS = numberOfPartialLIS[i]
        }
    }

    return numberOfLIS
};