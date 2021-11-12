using NUnit.Framework;
using LeetCode;

namespace LeetCode.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LongestPalindromeCheck(string input, string expected)
        {
            Assert.Equal(LongestPalindromeClass.LongestPalindrome(input), expected);
        }
    }
}