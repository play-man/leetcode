/*
You have two types of tiles: a 2 x 1 domino shape and a tromino shape. You may rotate these shapes.
Given an integer n, return the number of ways to tile an 2 x n board. Since the answer may be very large, return it modulo 109 + 7.

In a tiling, every square must be covered by a tile. Two tilings are different if and only if there are two 4-directionally adjacent cells on the board such that exactly one of the tilings has both squares occupied by a tile.

Constraints:

1 <= n <= 1000

*/

var numTilings = function (n) {
    let mod = 1000000007
    let memory = []
    memory[1] = 1
    memory[2] = 2
    memory[3] = 5
    for (let i = 4; i <= n; ++i)
        memory[i] = (2 * memory[i - 1] + memory[i - 3]) % mod
    return memory[n]
};