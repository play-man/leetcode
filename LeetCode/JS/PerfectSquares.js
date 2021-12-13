/*
Given an integer n, return the least number of perfect square numbers that sum to n.

A perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.

Constraints:

1 <= n <= 10^4
 */

var numSquares = function (n) {
    let memory = new Array(n + 1)
    memory[0] = 0
    let sqrtTemp = 0
    for (let i = 1; i <= n; ++i) {
        memory[i] = i
        sqrtTemp = Math.floor(Math.sqrt(i))
        for (let j = 1; j <= sqrtTemp; ++j) {
            if (memory[i - j * j] + 1 < memory[i])
                memory[i] = memory[i - j * j] + 1
        }
    }

    return memory[n]
};