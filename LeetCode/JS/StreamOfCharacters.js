/*
Design an algorithm that accepts a stream of characters and checks if a suffix of these characters is a string of a given array of strings words.

For example, if words = ["abc", "xyz"] and the stream added the four characters (one by one) 'a', 'x', 'y', and 'z', your algorithm should detect that the suffix "xyz" of the characters "axyz" matches "xyz" from words.

Implement the StreamChecker class:

StreamChecker(String[] words) Initializes the object with the strings array words.
boolean query(char letter) Accepts a new character from the stream and returns true if any non-empty suffix from the stream forms a word that is in words.

Constraints:

1 <= words.length <= 2000
1 <= words[i].length <= 2000
words[i] consists of lowercase English letters.
letter is a lowercase English letter.
At most 4 * 10^4 calls will be made to query.
 */

var TrieNode = function (content, children, isWord) {
    this.content = content
    this.children = children
    this.isWord = isWord
}

var StreamChecker = function (words) {
    this.letters = []
    this.root = new TrieNode('', [], false)
    let i = undefined
    let currentNode = undefined
    for (let word of words) {
        currentNode = this.root
        for (i = 0; i < word.length; ++i) {
            if (!currentNode.children[word[i]]) {
                currentNode.children[word[i]] = new TrieNode(currentNode.content + word[i], [], i == word.length - 1)
            }
            currentNode = currentNode.children[word[i]]
            if (i === word.length - 1)
                currentNode.isWord = true
        }
    }
};

StreamChecker.prototype.query = function (letter) {
    this.letters.push(letter)
    let i = undefined
    let j = undefined
    let trieCurrent = undefined
    for (i = this.letters.length - 1; i >= 0; --i) {
        trieCurrent = this.root
        for (j = i; j < this.letters.length; ++j) {
            if (trieCurrent.children[this.letters[j]]) {
                trieCurrent = trieCurrent.children[this.letters[j]]
            }
            else {
                trieCurrent = undefined
                break
            }
        }
        if (trieCurrent && trieCurrent.isWord) {
            return true
        }
    }
    return false
};