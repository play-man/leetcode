/*
 Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
typically using all the original letters exactly once.

Constraints:

1 <= strs.length <= 10^4
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
 */

var groupAnagrams = function (strs) {
    let dict = []
    for (let i = 0; i < strs.length; i++) {
        let composition = wordComposition(strs[i])
        dict[composition] ? dict[composition].push(strs[i]) : dict[composition] = [strs[i]]
    }
    return Object.entries(dict).map(x => x[1])
};

var wordComposition = function (str) {
    str = str.split('')
    str = str.sort()
    return str
};