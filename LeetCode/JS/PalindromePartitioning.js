/*
Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

A palindrome string is a string that reads the same backward as forward.

Constraints:

1 <= s.length <= 16
s contains only lowercase English letters.

*/

var partition = function (s) {
    let memory = []
    memory.push([])
    memory.push([[s[0]]])
    for (let i = 1; i < s.length; ++i) {
        memory.push(memory[i].map(arr => [...arr, s[i]]))

        // Look for new palindromes
        let isPalyndrome = true
        for (let j = i - 1; j >= 0; --j) {
            isPalyndrome = true
            for (let k = j; k <= (i + j) / 2; ++k) {
                if (s[k] != s[i + j - k]) {
                    isPalyndrome = false
                    break
                }
            }
            if (isPalyndrome) {
                if (j > 0)
                    memory[j].map(arr => memory[i + 1].push([...arr, s.substring(j, i + 1)]))
                else
                    memory[i + 1].push([s.substring(j, i + 1)])
            }
        }
    }
    return memory[s.length]
};