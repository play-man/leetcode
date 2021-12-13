/*
The power of the string is the maximum length of a non-empty substring that contains only one unique character.

Given a string s, return the power of s.

Constraints:

1 <= s.length <= 500
s consists of only lowercase English letters.

*/

var maxPower = function (s) {
    let currentChar = ''
    let currentMax = 0
    let max = 0
    for (let i = 0; i < s.length; ++i) {
        if (s[i] != currentChar) {
            if (currentMax > max)
                max = currentMax
            currentMax = 1
            currentChar = s[i]
        }
        else
            currentMax++
    }
    if (currentMax > max)
        max = currentMax
    return max
};