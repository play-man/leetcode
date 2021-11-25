/*
 * Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

The replacement must be in place and use only constant extra memory.

Constraints:

1 <= nums.length <= 100
0 <= nums[i] <= 100
 */
var nextPermutation = function (nums) {
    let curToShift = -1;
    let curToSwap = -1;
    let len = nums.length;
    for (let i = len - 2; i >= 0; --i) {
        if (nums[i] < nums[i + 1]) {
            curToShift = i;
            curToSwap = i + 1;
            break;
        }
    }
    let a = (curToShift + len);
    let middle = a / 2;
    for (let i = curToShift + 1; i <= middle; ++i) {
        let b = nums[i];
        nums[i] = nums[a - i];
        nums[a - i] = b;
    }
    for (let i = curToShift + 1; i < len; ++i) {
        if (nums[i] > nums[curToShift]) {
            curToSwap = i;
            break;
        }
    }
    if (curToShift >= 0) {
        let c = nums[curToShift];
        nums[curToShift] = nums[curToSwap];
        nums[curToSwap] = c;
    }
};