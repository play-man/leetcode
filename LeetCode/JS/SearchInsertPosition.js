/*Given a sorted array of distinct integers and a target value, return the index if the target is found. 
 If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

 */
var searchInsert = function (nums, target) {
    if (nums.length === 1)
        if (target <= nums[0])
            return 0
        else return 1
    if (target <= nums[0])
        return 0
    else if (target > nums[nums.length - 1])
        return nums.length
    else return searchInsertBinary(nums, target, 0, nums.length - 1)
};

var searchInsertBinary = function (nums, target, start, end) {
    if (start === end - 1) {
        if (target === nums[start])
            return start
        else return end
    }
    let middle = Math.floor((start + end) / 2)
    if (nums[middle] === target)
        return middle
    else if (nums[middle] > target)
        return searchInsertBinary(nums, target, start, middle)
    else return searchInsertBinary(nums, target, middle, end)
};