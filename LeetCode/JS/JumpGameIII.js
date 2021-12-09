/*
Given an array of non-negative integers arr, you are initially positioned at start index of the array. When you are at index i, you can jump to i + arr[i] or i - arr[i], check if you can reach to any index with value 0.

Notice that you can not jump outside of the array at any time.

Constraints:

1 <= arr.length <= 5 * 10^4
0 <= arr[i] < arr.length
0 <= start < arr.length

*/

var canReach = function (arr, start) {
    let arrVisited = new Array(arr.length).fill(0);
    let canReachResult = false

    let canReachHelper = function (arr, arrVisited, start) {
        arrVisited[start] = 1
        if (arr[start] === 0) {
            canReachResult = true
            return
        }
        if ((start - arr[start] >= 0) && (arrVisited[start - arr[start]] === 0) && !canReachResult) {
            canReachHelper(arr, arrVisited, start - arr[start])
        }
        if ((start + arr[start] < arr.length) && (arrVisited[start + arr[start]] === 0) && !canReachResult) {
            canReachHelper(arr, arrVisited, start + arr[start])
        }
    }

    canReachHelper(arr, arrVisited, start)
    return canReachResult
};
