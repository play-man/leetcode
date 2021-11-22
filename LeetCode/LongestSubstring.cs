using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class LongestSubstring
    {
        /*Given a string s, find the length of the longest substring without repeating characters.
         
        Constraints:

        0 <= s.length <= 5 * 10^4
        s consists of English letters, digits, symbols and spaces.*/
        public int LengthOfLongestSubstring(string s)
        {

            if (s.Length == 0) return 0;

            int result = 1;

            int[] distanceToLastSimilar = new int[s.Length];
            Dictionary<char, int> lastOccurence = new Dictionary<char, int>();
            // Marks the latest index where distanceToLastSimilar
            // and lastOccurence were correctly identified
            int lastIndexesSet = -1;
            int currentStart = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (i > lastIndexesSet)
                {
                    if (!lastOccurence.ContainsKey(s[i]))
                    {
                        distanceToLastSimilar[i] = i + 1;
                        lastOccurence.Add(s[i], i);
                    }
                    else
                    {
                        distanceToLastSimilar[i] = i - lastOccurence[s[i]];
                        lastOccurence[s[i]] = i;
                    }
                    lastIndexesSet = i;
                }

                // If the substring [currentStart;i-1] has the symbol s[i]
                if (distanceToLastSimilar[i] < i - currentStart + 1)
                {
                    currentStart = i - distanceToLastSimilar[i] + 1;
                    i = currentStart - 1;
                    // i should be equal to currentStart, but it's gonna be 
                    // autoincremented at the end of the loop
                }
                else if (i - currentStart + 1 > result)
                    result = i - currentStart + 1;
            }
            return result;
        }
    }
}
