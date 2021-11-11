using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Atoi
    {
        public int MyAtoi(string s)
        {
            int n = s.Length;
            int MIN = -2147483648;
            int MAX = 2147483647;
            string MIN_STRING = "2147483648";
            string MAX_STRING = "2147483647";
            bool isNegative = false;
            bool shouldStop = false;
            bool areLeadingWhitespacesPassed = false;
            bool areLeadingZerosPassed = false;
            int numberStartIndex = -1;
            int dashIndex = -1;
            int firstDigitIndex = -1;
            List<int> digits = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                char a = s[i];
                int digit = -1;
                switch (a)
                {
                    case ' ':
                        {
                            if (areLeadingWhitespacesPassed)
                                shouldStop = true;
                            break;
                        }
                    case '-':
                        {
                            areLeadingWhitespacesPassed = true;
                            if (dashIndex < 0)
                                dashIndex = i;
                            if (numberStartIndex < 0)
                                numberStartIndex = i;
                            break;
                        }
                    case '+':
                        {
                            areLeadingWhitespacesPassed = true;
                            if (numberStartIndex < 0)
                                numberStartIndex = i;
                            break;
                        }
                    case '0':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 0;
                            break;
                        }
                    case '1':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 1;
                            break;
                        }
                    case '2':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 2;
                            break;
                        }
                    case '3':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 3;
                            break;
                        }
                    case '4':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 4;
                            break;
                        }
                    case '5':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 5;
                            break;
                        }
                    case '6':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 6;
                            break;
                        }
                    case '7':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 7;
                            break;
                        }
                    case '8':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 8;
                            break;
                        }
                    case '9':
                        {
                            areLeadingWhitespacesPassed = true;
                            digit = 9;
                            break;
                        }
                    default:
                        {
                            shouldStop = true;
                            break;
                        }
                }

                if (digit >= 0)
                {
                    if (firstDigitIndex < 0)
                        firstDigitIndex = i;
                    if (numberStartIndex < 0)
                        numberStartIndex = i;
                    if (digit > 0)
                    {
                        digits.Add(digit);
                        areLeadingZerosPassed = true;
                    }
                    else if (areLeadingZerosPassed)
                    {
                        digits.Add(digit);
                    }
                }
                else if ((i > numberStartIndex) && (numberStartIndex >= 0))
                    shouldStop = true;

                if (shouldStop)
                    break;
            }

            if ((firstDigitIndex - dashIndex == 1) && (dashIndex >= 0))
                isNegative = true;

            if (digits.Count >= 11)
            {
                return isNegative ? MIN : MAX;
            }
            else if (digits.Count == 10)
            {
                if (isNegative)
                {
                    if (string.Compare(s.Substring(firstDigitIndex, 10), MIN_STRING, StringComparison.Ordinal) > 0)
                    {
                        return MIN;
                    }
                    else
                    {
                        int result = digits[0];
                        for (int i = 1; i < digits.Count; ++i)
                        {
                            result = 10 * result + digits[i];
                        }
                        return -result;
                    }
                }
                else
                {
                    if (string.Compare(s.Substring(firstDigitIndex, 10), MAX_STRING, StringComparison.Ordinal) > 0)
                    {
                        return MAX;
                    }
                    else
                    {
                        int result = digits[0];
                        for (int i = 1; i < digits.Count; ++i)
                        {
                            result = 10 * result + digits[i];
                        }
                        return result;
                    }
                }
            }
            else if (digits.Count > 0)
            {
                int result = digits[0];
                for (int i = 1; i < digits.Count; ++i)
                {
                    result = 10 * result + digits[i];
                }
                return isNegative ? -result : result;
            }
            else return 0;
        }
    }
}
