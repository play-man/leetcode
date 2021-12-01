/*
You are a professional robber planning to rob houses along a street. 
Each house has a certain amount of money stashed, the only constraint stopping you from robbing 
each of them is that adjacent houses have security systems connected and it will automatically contact the police 
if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, 
return the maximum amount of money you can rob tonight without alerting the police.

Constraints:

1 <= nums.length <= 100
0 <= nums[i] <= 400
 */

var rob = function (nums) {
    let maxRob = new Array(nums.length)
    if (nums.length >= 1)
        maxRob[0] = nums[0]
    if (nums.length >= 2)
        maxRob[1] = Math.max(nums[0], nums[1])

    for (let i = 2; i < nums.length; ++i) {
        maxRob[i] = Math.max(nums[i] + maxRob[i - 2], nums[i - 1] + (i > 2 ? maxRob[i - 3] : 0))
    }
    console.log(maxRob)
    return maxRob[nums.length - 1]
};