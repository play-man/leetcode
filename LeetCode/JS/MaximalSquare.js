/*
Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 300
matrix[i][j] is '0' or '1'.
 */

var maximalSquare = function (matrix) {
    let m = matrix.length
    if (m === 0) return 0
    let n = matrix[0].length
    let maxArea = 0
    let heightsStack = []
    let currentRect = []
    let currentWidth = 0
    let currentAreaArray = new Array(n).fill(0)

    // The idea is to calculate the biggest rectangle with topmost row at i-th index
    // starting from bottom, though only for better intuitive understanding
    // E.g.: 
    // Input: ["1","1","1","0","1"]
    //        ["1","0","0","1","0"]
    // Iteration 1: currentAreaArray = ["1","0","0","1","0"]
    // Iteration 2: currentAreaArray = ["2","1","1","0","1"]
    // Iteration 2: currentWidth = length of non-zero subseries
    // Iteration 2: currentHeight = minimum height in this non-zero subseries
    let i = m - 1
    let j = 0
    for (i = m - 1; i >= 0; --i) {
        heightsStack = []
        for (j = 0; j < n; ++j) {
            currentAreaArray[j] = matrix[i][j] === '0' ? 0 : currentAreaArray[j] + 1;
            while (heightsStack.length > 0 && currentAreaArray[j] < heightsStack[heightsStack.length - 1][0]) {
                currentRect = heightsStack.pop()
                currentWidth = heightsStack.length == 0 ? j : j - heightsStack[heightsStack.length - 1][1] - 1
                if (currentWidth == currentRect[0])
                    maxArea = Math.max(maxArea, currentWidth * currentRect[0])
            }
            heightsStack.push([currentAreaArray[j], j])
        }
        while (heightsStack.length > 0) {
            currentRect = heightsStack.pop()
            currentWidth = heightsStack.length == 0 ? n : n - heightsStack[heightsStack.length - 1][1] - 1
            if (currentWidth == currentRect[0])
                maxArea = Math.max(maxArea, currentWidth * currentRect[0])
        }
    }
    return maxArea
};