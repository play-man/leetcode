using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class MultiplyStrings
    {
        /*
        Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
        
        Constraints:

        1 <= num1.length, num2.length <= 200
        num1 and num2 consist of digits only.
        Both num1 and num2 do not contain any leading zero, except the number 0 itself.
        
        */
        public static string Multiply(string num1, string num2)
        {
            //Console.WriteLine("A" + num1);
            //Console.WriteLine("B" + num2);
            if (num1.Length == 0 || num2.Length == 0) return "0";
            if ((num1.Count(c => c == '0') == num1.Length) || (num2.Count(c => c == '0') == num2.Length)) return "0";

            if (num1.Length == 1 && num2.Length == 1) return ((num1[0] - 48) * (num2[0] - 48)).ToString();

            // Make strings equally long
            int maxLength = Math.Max(num1.Length, num2.Length);
            int m = maxLength / 2;
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');

            // An implementation of Karatsuba algorithm
            string a1 = num1.Substring(0, maxLength - m);
            string a0 = num1.Substring(maxLength - m, m);

            string b1 = num2.Substring(0, maxLength - m);
            string b0 = num2.Substring(maxLength - m, m);

            string basem = "".PadLeft(m, '0');
            string base2m = "".PadLeft(2 * m, '0');

            return Add(Add(Multiply(a0, b0), Subtract(Subtract(Multiply(Add(a0, a1), Add(b0, b1)), Multiply(a0, b0)), Multiply(a1, b1)) + basem), Multiply(a1, b1) + base2m);
        }

        public static string Subtract(string num1, string num2)
        {
            if (num1.Length == 0 || num2.Length == 0) return "0";
            // Subtract assumes num1 >= num2 always
            // Make strings equally long
            int maxLength = num1.Length;
            num2 = num2.PadLeft(maxLength, '0');

            StringBuilder result = new StringBuilder("".PadLeft(maxLength, '0'));
            result[0] = '0';

            // Start subtracting
            for (int i = 0; i < maxLength; ++i)
            {
                int n = num1[i] - num2[i];
                if (n >= 0)
                    result[i] = (char)(n + 48);
                else if (i > 0)
                {
                    result[i] = (char)(10 + n + 48);
                    int index = i - 1;
                    // Move to next base until possible
                    while (result[index] == '0')
                    {
                        result[index] = '9';
                        index--;
                    }
                    result[index] = (char)(result[index] - 1);
                }
            }
            return result.ToString().TrimStart('0');
        }

        public static string Add(string num1, string num2)
        {
            if (num1.Length == 0)
                return num2;
            else if (num2.Length == 0)
                return num1;
            // Make strings equally long
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');


            StringBuilder result = new StringBuilder("".PadLeft(maxLength + 1, '0'));

            // Start adding
            for (int i = 0; i < maxLength; ++i)
            {
                int n = num1[i] + num2[i] - 96;
                if (n < 10)
                    result[i + 1] = (char)(n + 48);
                else
                {
                    int index = i;
                    result[i + 1] = (char)(n - 10 + 48);
                    // Move to next base until possible
                    while (result[index] == '9')
                    {
                        result[index] = '0';
                        index--;
                    }
                    result[index] = (char)(result[index] + 1);
                }
            }

            return result.ToString().TrimStart('0');
        }
    }
}
