/*
Given two strings s and t, return the number of distinct subsequences of s which equals t.

A string's subsequence is a new string formed from the original string by deleting some (can be none) of the characters without disturbing the remaining characters' relative positions. (i.e., "ACE" is a subsequence of "ABCDE" while "AEC" is not).

The test cases are generated so that the answer fits on a 32-bit signed integer.

Constraints:

1 <= s.length, t.length <= 1000
s and t consist of English letters.
*/

var numDistinct = function (s, t) {
    if (s.length < t.length)
        return 0

    memory = new Array(t.length + 1).fill(0)
    memory[0] = 1

    for (let i = 0; i < s.length; ++i) {
        for (let j = t.length - 1; j >= 0; --j) {
            if (s[i] === t[j])
                memory[j + 1] += memory[j]
        }
    }

    return memory[t.length]
};