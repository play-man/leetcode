using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*Given a string s containing only digits, return all possible valid IP addresses that can be obtained from s. You can return them in any order.

    A valid IP address consists of exactly four integers, each integer is between 0 and 255, separated by single dots and cannot have leading zeros. 
    For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses and "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.*/ 
    internal static class IPAddress
    {
        public static IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            if (s.Length <= 12)
            {
                // i, j, k - positions of dots in IP address - index represents an index of digit, which is preceeded by a dot
                for (int i = 1; i <= s.Length - 3; i++)
                    for (int j = i + 1; j <= s.Length - 2; j++)
                        for (int k = j + 1; k <= s.Length - 1; k++)
                        {
                            string first = s.Substring(0, i);
                            string second = s.Substring(i, j - i);
                            string third = s.Substring(j, k - j);
                            string fourth = s.Substring(k, s.Length - k);
                            if (IsValid(first) && IsValid(second) 
                                && IsValid(third) && IsValid(fourth))
                                result.Add(String.Format("{0}.{1}.{2}.{3}", first, second, third, fourth));
                        }
            }
            return result;
        }

        public static bool IsValid(string s)
        {
            bool isNum = Int32.TryParse(s, out int num);
            return ((!(s.StartsWith("0") && s.Length >= 2)) && isNum && num < 256 && num >= 0);
        }
    }
}
