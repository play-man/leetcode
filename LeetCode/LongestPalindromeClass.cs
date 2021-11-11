using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class LongestPalindromeClass
    {
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 0) return String.Empty;
            else if (s.Length == 1) return s;
            else if (s.Length == 2) return s[0] == s[1] ? s : s.Substring(1);
            else
            {
                int startIndex = 0;
                int endIndex = 0;
                // Check for odd palindroms
                for (int i = 1; i < s.Length - 1; ++i)
                {
                    int maxLength = Math.Min(i, s.Length - i - 1);
                    for (int j = 1; j <= maxLength; ++j)
                    {
                        if ((s[i - j] != s[i + j]))
                            break;
                        else if (2 * j + 1 > endIndex - startIndex)
                        {
                            startIndex = i - j;
                            endIndex = i + j;
                        }
                    }
                }
                // Check for even palindroms
                for (int i = 1; i < s.Length; ++i)
                {
                    if (s[i] == s[i - 1])
                    {
                        if (2 > endIndex - startIndex)
                        {
                            startIndex = i - 1;
                            endIndex = i;
                        }
                        int maxLength = Math.Min(i - 1, s.Length - i - 1);
                        for (int j = 1; j <= maxLength; ++j)
                        {
                            if ((s[i - 1 - j] != s[i + j]))
                                break;
                            else if (2 * j + 2 > endIndex - startIndex)
                            {
                                startIndex = i - 1 - j;
                                endIndex = i + j;
                            }
                        }
                    }
                }
                return s.Substring(startIndex, endIndex - startIndex + 1);
            }
        }

        public static bool IsPalindrome(string s)
        {
            char[] charArray = s.ToCharArray();
            char[] charArrayToReverse = charArray;
            Array.Reverse(charArrayToReverse);
            return charArray.SequenceEqual(charArrayToReverse);
        }
    }
}
