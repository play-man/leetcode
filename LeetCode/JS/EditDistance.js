/*
Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

You have the following three operations permitted on a word:

Insert a character
Delete a character
Replace a character

Constraints:

0 <= word1.length, word2.length <= 500
word1 and word2 consist of lowercase English letters.

*/

var minDistance = function (word1, word2) {
    let memory = new Array(word1.length + 1)
    memory[0] = []
    for (let i = 0; i <= word2.length; ++i)
        memory[0].push(i)
    for (let i = 1; i <= word1.length; ++i) {
        memory[i] = new Array(word2.length + 1)
        memory[i][0] = i
    }
    for (let i = 1; i <= word1.length; ++i)
        for (let j = 1; j <= word2.length; ++j) {
            memory[i][j] = Math.min((word1[i - 1] === word2[j - 1] ? 0 : 1) + memory[i - 1][j - 1], 1 + memory[i - 1][j], 1 + memory[i][j - 1])

        }

    return memory[word1.length][word2.length]
};