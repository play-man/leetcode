/*
You are given an integer array nums. Two players are playing a game with this array: player 1 and player 2.

Player 1 and player 2 take turns, with player 1 starting first. Both players start the game with a score of 0. At each turn, the player takes one of the numbers from either end of the array (i.e., nums[0] or nums[nums.length - 1]) which reduces the size of the array by 1. The player adds the chosen number to their score. The game ends when there are no more elements in the array.

Return true if Player 1 can win the game. If the scores of both players are equal, then player 1 is still the winner, and you should also return true. You may assume that both players are playing optimally.

Constraints:

1 <= nums.length <= 20
0 <= nums[i] <= 10^7

*/
var PredictTheWinner = function (nums) {
    if (nums.length <= 2)
        return true
    let memory = []
    for (let i = 0; i < nums.length; ++i) {
        memory.push([])
        for (let j = 0; j < nums.length; ++j) {
            memory[i].push(undefined)
        }
    }

    var PredictTheWinnerHelper = function (nums, start, end) {
        if (memory[start][end] !== undefined) {

        }
        else if (end === start) {
            memory[start][end] = nums[start]
        }
        else if (end - start === 1) {
            memory[start][end] = Math.abs(nums[start] - nums[end])
        }
        else {
            memory[start][end] = Math.max(nums[start] + Math.min(PredictTheWinnerHelper(nums, start + 1, end - 1) - nums[end], PredictTheWinnerHelper(nums, start + 2, end) - nums[start + 1]), nums[end] + Math.min(PredictTheWinnerHelper(nums, start + 1, end - 1) - nums[start], PredictTheWinnerHelper(nums, start, end - 2) - nums[end - 1]))
        }

        return memory[start][end]
    }

    PredictTheWinnerHelper(nums, 0, nums.length - 1)
    return memory[0][nums.length - 1] >= 0

};
