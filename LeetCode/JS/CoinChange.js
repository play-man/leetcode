/*
You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

Constraints:

1 <= coins.length <= 12
1 <= coins[i] <= 2^31 - 1
0 <= amount <= 10^4
 */

var coinChange = function (coins, amount) {
    let results = []
    let i = 0
    let j = 0
    for (i = 0; i < amount; ++i) {
        results[i] = -1
        if (coins.indexOf(i + 1) >= 0)
            results[i] = 1
        for (j = 0; j < coins.length; ++j) {
            if (i - coins[j] >= 0) {
                if (results[i - coins[j]] > 0 && (results[i] < 0 || results[i] > results[i - coins[j]] + 1)) {
                    results[i] = results[i - coins[j]] + 1
                }
            }
        }
    }
    return amount !== 0 ? results[amount - 1] : 0
};