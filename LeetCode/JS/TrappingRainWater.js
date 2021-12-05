/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it can trap after raining.

Constraints:

n == height.length
1 <= n <= 2 * 10^4
0 <= height[i] <= 10^5
 */

var trap = function (height) {
    let i = 0
    let j = height.length - 1
    let waterLevel = 0
    let waterAmount = 0
    let lower = 0
    while (i < j) {
        lower = height[i] < height[j] ? height[i] : height[j]
        height[i] < height[j] ? i++ : j--
        waterLevel = Math.max(lower, waterLevel)
        waterAmount += waterLevel - lower
    }
    return waterAmount
};