/*
Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

An interleaving of two strings s and t is a configuration where they are divided into non-empty substrings such that:

s = s1 + s2 + ... + sn
t = t1 + t2 + ... + tm
|n - m| <= 1
The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
Note: a + b is the concatenation of strings a and b.

Constraints:

0 <= s1.length, s2.length <= 100
0 <= s3.length <= 200
s1, s2, and s3 consist of lowercase English letters.
 */

var isInterleave = function (s1, s2, s3) {
    let memory = []

    var isInterleaveHelper = function (s1, s2, s3) {
        if (memory[`${s1} ${s2} ${s3}`])
            return memory[`${s1} ${s2} ${s3}`]
        if (s1 === "" && s2 === "" && s3 === "") {
            memory[`${s1} ${s2} ${s3}`] = true
            return true
        }
        let temp = 0
        while (temp < s1.length && temp < s3.length && s1[temp] == s3[temp])
            temp++

        let tempResult = false
        let i = 0
        for (i = 0; i < temp; ++i) {
            tempResult = tempResult || isInterleaveHelper(s2, s1.slice(i + 1), s3.slice(i + 1))
        }
        memory[`${s1} ${s2} ${s3}`] = tempResult
        return memory[`${s1} ${s2} ${s3}`]
    }

    return isInterleaveHelper(s1, s2, s3) || isInterleaveHelper(s2, s1, s3)
};
