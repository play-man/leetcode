/*
Given an unsorted integer array nums, return the smallest missing positive integer.

You must implement an algorithm that runs in O(n) time and uses constant extra space.

Constraints:

1 <= nums.length <= 5 * 10^5
-2^31 <= nums[i] <= 2^31 - 1
 */

var firstMissingPositive = function (nums) {
    // We'll convert nums into an indicator array
    // because first missing belongs to [1, len + 1]

    // Nullify negative numbers
    for (let i = 0; i < nums.length; ++i)
        if (nums[i] < 0)
            nums[i] = 0
    // Make number negative if it is in the array
    for (let i = 0; i < nums.length; ++i) {
        abs = Math.abs(nums[i])
        if ((abs <= nums.length) && (abs >= 1)) {
            if (nums[abs - 1] > 0)
                nums[abs - 1] *= -1
            else if (nums[abs - 1] === 0)
                nums[abs - 1] = -(nums.length + i)
        }
    }
    // Look for first positive number.
    // If number is positive, it wasn't affected
    for (let i = 0; i < nums.length; ++i) {
        if (nums[i] >= 0)
            return i + 1
    }
    return nums.length + 1
};