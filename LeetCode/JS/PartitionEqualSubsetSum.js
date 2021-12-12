/*
Given a non-empty array nums containing only positive integers, 
find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Constraints:

1 <= nums.length <= 200
1 <= nums[i] <= 100

*/

var canPartition = function (nums) {
    let set = new Set()
    set.add(nums[0])
    set.add(-nums[0])
    for (let i = 1; i < nums.length; ++i) {
        let tempSet = new Set()
        for (let val of set) {
            tempSet.add(val - nums[i])
            tempSet.add(val + nums[i])
        }
        set = tempSet;
    }
    return set.has(0)
};