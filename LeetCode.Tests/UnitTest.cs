using NUnit.Framework;
using LeetCode;
using Moq;

namespace LeetCode.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("abbba", "abbba")]
        [TestCase("", "")]
        [TestCase("_000", "000")]
        public void PalindromeCheck(string input, string result)
        {
            Assert.AreEqual(LongestPalindromeClass.LongestPalindrome(input), result);
        }
    }
}