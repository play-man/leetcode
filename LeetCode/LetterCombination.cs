using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class LetterCombination
    {
        private static readonly Dictionary<char, List<char>> mapping = new Dictionary<char, List<char>>()
        {
            { '2', new List<char>() {'a', 'b', 'c'}},
            { '3', new List<char>() {'d', 'e', 'f'}},
            { '4', new List<char>() {'g', 'h', 'i'}},
            { '5', new List<char>() {'j', 'k', 'l'}},
            { '6', new List<char>() {'a', 'b', 'c'}},
            { '7', new List<char>() {'a', 'b', 'c'}},
            { '8', new List<char>() {'a', 'b', 'c'}},
            { '9', new List<char>() {'a', 'b', 'c'}},
        };
        public static IList<string> LetterCombinations(string digits)
        { 
            List<string> list = new List<string>();
            if (digits.Length == 0)
                return new List<string>();
            else if (digits[0] == '2')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('a' + str);
                    list.Add('b' + str);
                    list.Add('c' + str);
                }
            }
            else if (digits[0] == '3')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('d' + str);
                    list.Add('e' + str);
                    list.Add('f' + str);
                }
            }
            else if (digits[0] == '4')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('g' + str);
                    list.Add('h' + str);
                    list.Add('i' + str);
                }
            }
            else if (digits[0] == '5')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('j' + str);
                    list.Add('k' + str);
                    list.Add('l' + str);
                }
            }
            else if (digits[0] == '6')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('m' + str);
                    list.Add('n' + str);
                    list.Add('o' + str);
                }
            }
            else if (digits[0] == '7')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('p' + str);
                    list.Add('q' + str);
                    list.Add('r' + str);
                    list.Add('s' + str);
                }
            }
            else if (digits[0] == '8')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('t' + str);
                    list.Add('u' + str);
                    list.Add('v' + str);
                }
            }
            else if (digits[0] == '9')
            {
                IList<string> prev = LetterCombinations(digits.Substring(1));
                if (prev.Count == 0)
                    prev.Add("");
                foreach (string str in prev)
                {
                    list.Add('w' + str);
                    list.Add('x' + str);
                    list.Add('y' + str);
                    list.Add('z' + str);
                }
            }
            return list;
        }
    }
}
