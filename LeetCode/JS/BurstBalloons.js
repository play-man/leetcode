/*
You are given n balloons, indexed from 0 to n - 1. Each balloon is painted with a number on it represented by an array nums. You are asked to burst all the balloons.

If you burst the ith balloon, you will get nums[i - 1] * nums[i] * nums[i + 1] coins. If i - 1 or i + 1 goes out of bounds of the array, then treat it as if there is a balloon with a 1 painted on it.

Return the maximum coins you can collect by bursting the balloons wisely.

Constraints:

n == nums.length
1 <= n <= 500
0 <= nums[i] <= 100

*/

var maxCoins = function (nums) {
    let memory = []
    for (let i = 0; i < nums.length + 2; ++i) {
        memory.push(new Array(nums.length))
    }
    nums.unshift(1)
    nums.push(1)

    var maxCoinsHelper = function (nums, start, end) {
        if (memory[start][end] !== undefined) {

        }
        else if (start >= end) {
            memory[start][end] = 0
        }
        else {
            let temp = 0
            let left = 0
            let right = 0
            for (let i = start; i < end; ++i) {
                left = maxCoinsHelper(nums, start, i)
                right = maxCoinsHelper(nums, i + 1, end)

                temp = Math.max(temp, left + right + (nums[start - 1]) * nums[end] * nums[i])
            }
            memory[start][end] = temp
        }
        return memory[start][end]
    };

    let t = maxCoinsHelper(nums, 1, nums.length - 1)
    return t
};

