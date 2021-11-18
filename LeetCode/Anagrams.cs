using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Anagrams
    {
        /*
         Given two strings s and p, return an array of all the start indices of p's anagrams in s. 
        You may return the answer in any order.

        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
        typically using all the original letters exactly once.
        
        Constraints:

        1 <= s.length, p.length <= 3 * 10^4
        s and p consist of lowercase English letters.*/
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();
            int pLen = p.Length;
            int sLen = s.Length;
            if (sLen >= pLen)
            {
                // Stores letters of p that are missing in the substring of s [i, i+p]
                List<char> currentWordDifference = new List<char>();
                // Stores letter of s that couldn't be deleted from currentWordDifference
                // because they are yet to be added there
                // Example: s = "abac", p = "abc"
                // Since "aba" is missing c, we'll need to delete c later as we iterate 
                // through pLen-substrings of s
                List<char> charsToDelete = new List<char>();
                for (int i = 0; i < pLen; ++i)
                    currentWordDifference.Add(s[i]);
                for (int i = 0; i < pLen; ++i)
                {
                    if (!currentWordDifference.Remove(p[i]))
                        charsToDelete.Add(p[i]);
                }
                if (currentWordDifference.Count == 0)
                    result.Add(0);
                for (int i = pLen; i < sLen; ++i)
                {
                    currentWordDifference.Add(s[i]);
                    for (int j = 0; j < charsToDelete.Count; ++j)
                    {
                        if (currentWordDifference.Remove(charsToDelete[j]))
                        {
                            charsToDelete.RemoveAt(j);
                            j--;
                        }
                    }
                    if (!currentWordDifference.Remove(s[i - pLen]))
                        charsToDelete.Add(s[i - pLen]);
                    if (currentWordDifference.Count == 0)
                        result.Add(i - pLen + 1);
                }
            }
            return result;
        }
    }
}
