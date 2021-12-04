/*
Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

Constraints:

1 <= triangle.length <= 200
triangle[0].length == 1
triangle[i].length == triangle[i - 1].length + 1
-10^4 <= triangle[i][j] <= 10^4

*/

var minimumTotal = function (triangle) {
    let pathSumTriangle = []
    let i = 0
    let j = 0
    for (i = 0; i < triangle.length; ++i)
        pathSumTriangle.push(new Array(i + 1))

    for (i = 0; i < triangle.length; ++i)
        pathSumTriangle[triangle.length - 1][i] = triangle[triangle.length - 1][i]

    for (i = triangle.length - 2; i >= 0; --i) {
        for (j = 0; j <= i; ++j)
            pathSumTriangle[i][j] = triangle[i][j] + Math.min(pathSumTriangle[i + 1][j], pathSumTriangle[i + 1][j + 1])
    }

    return pathSumTriangle[0, 0]
    return
};