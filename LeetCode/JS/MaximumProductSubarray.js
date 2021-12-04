/*
Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

It is guaranteed that the answer will fit in a 32-bit integer.

A subarray is a contiguous subsequence of the array.

Constraints:

1 <= nums.length <= 2 * 10^4
-10 <= nums[i] <= 10
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 */

var maxProduct = function (nums) {
    let zeroIndexes = []
    let result = Number.NEGATIVE_INFINITY
    let currentProduct = 1
    let seriesStart = 0
    let seriesEnd = 0
    let seriesExists = false
    let leftmostNegativeIndex = 0
    let rightmostNegativeIndex = 0
    let productLeft = 1
    let productRight = 1

    for (let i = 0; i <= nums.length; ++i) {
        if ((nums[i] === 0) || (i == nums.length)) {
            if (nums[i] === 0)
                result = Math.max(result, 0)
            if (seriesExists) {
                if (currentProduct > 0) {
                    result = Math.max(result, currentProduct)
                }
                else if (seriesEnd === seriesStart) {
                    result = Math.max(result, currentProduct)
                }
                else {
                    leftmostNegativeIndex = seriesStart
                    rightmostNegativeIndex = seriesEnd
                    productLeft = currentProduct
                    productRight = currentProduct
                    while (leftmostNegativeIndex <= seriesEnd && nums[leftmostNegativeIndex] > 0) {
                        productLeft /= nums[leftmostNegativeIndex]
                        leftmostNegativeIndex++
                    }

                    while (rightmostNegativeIndex >= seriesStart && nums[rightmostNegativeIndex] > 0) {
                        productRight /= nums[rightmostNegativeIndex]
                        rightmostNegativeIndex--
                    }
                    productLeft /= nums[leftmostNegativeIndex]
                    productRight /= nums[rightmostNegativeIndex]

                    result = Math.max(result, productLeft, productRight)
                }
            }

            currentProduct = 1
            seriesStart = i + 1
            seriesEnd = i + 1
            seriesExists = false
        }
        else {
            seriesExists = true
            currentProduct *= nums[i]
            seriesEnd = i
        }
    }
    return result
};