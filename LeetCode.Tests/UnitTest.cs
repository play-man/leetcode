using NUnit.Framework;
using LeetCode;
using Moq;
using System.Linq;
using System.Collections.Generic;

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

        [Test]
        public void SudokuCheck1()
        {
            char[][] test = new char[][]
            {
                new char[]{'8','3','.','.','7','.','.','.','.'},
                new char[]{'6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.'},
                new char[]{'8','.','.','.','6','.','.','.','3'},
                new char[]{'4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6'},
                new char[]{'.','6','.','.','.','.','2','8','.'},
                new char[]{'.','.','.','4','1','9','.','.','5'},
                new char[]{'.','.','.','.','8','.','.','7','9'},
            };
            Assert.AreEqual(ValidSudoku.IsValidSudoku(test), false);
        }

        [Test]
        public void SudokuCheck2()
        {
            char[][] test = new char[][]
            {
                new char[]{'5','3','.','.','7','.','.','.','.'},
                new char[]{'6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.'},
                new char[]{'8','.','.','.','6','.','.','.','3'},
                new char[]{'4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6'},
                new char[]{'.','6','.','.','.','.','2','8','.'},
                new char[]{'.','.','.','4','1','9','.','.','5'},
                new char[]{'.','.','.','.','8','.','.','7','9'},
            };
            Assert.AreEqual(ValidSudoku.IsValidSudoku(test), true);
        }

        [Test]
        public void JumpCheck()
        {
            int[] test = new int[]
            {
                2,3,1,1,4
            };
            Assert.AreEqual(JumpGame.Jump(test), 2);
        }

        [Test]
        public void JumpCheck2()
        {
            int[] test = new int[]
            {
                2,3,0,1,4
            };
            Assert.AreEqual(JumpGame.Jump(test), 2);
        }

        [Test]
        public void JumpCheck3()
        {
            int[] test = new int[]
            {
                6,1,1,1,1,1,1,1,1,1
            };
            Assert.AreEqual(JumpGame.Jump(test), 4);
        }

        [Test]
        public void JumpCheck4()
        {
            int[] test = new int[]
            {
                3,2,1
            };
            Assert.AreEqual(JumpGame.Jump(test), 1);
        }

        [Test]
        public void JumpCheck5()
        {
            int[] test = new int[]
            {
                3,1,1,4,1
            };
            Assert.AreEqual(JumpGame.Jump(test), 2);
        }

        [Test]
        public void SudokuSolverCellOptionsCheck()
        {
            char[][] test = new char[][]
            {
                new char[]{'5','3','.','.','7','.','.','.','.'},
                new char[]{'6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.'},
                new char[]{'8','.','.','.','6','.','.','.','3'},
                new char[]{'4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6'},
                new char[]{'.','6','.','.','.','.','2','8','.'},
                new char[]{'.','.','.','4','1','9','.','.','5'},
                new char[]{'.','.','.','.','8','.','.','7','9'},
            };
            Assert.True(Enumerable.SequenceEqual(SudokuSolver.CellOptions(test, 3, 1), new List<char> { '1', '2', '5' }));
        }

        [Test]
        public void SudokuSolverCheck()
        {
            char[][] test = new char[][]
            {
                new char[]{'5','3','.','.','7','.','.','.','.'},
                new char[]{'6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.'},
                new char[]{'8','.','.','.','6','.','.','.','3'},
                new char[]{'4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6'},
                new char[]{'.','6','.','.','.','.','2','8','.'},
                new char[]{'.','.','.','4','1','9','.','.','5'},
                new char[]{'.','.','.','.','8','.','.','7','9'},
            };
            char[][] testSolved = SudokuSolver.SolveSudoku(test);
            char[][] expected = new char[][]
            {
                new char[]{'5','3','4','6','7','8','9','1','2'},
                new char[]{'6','7','2','1','9','5','3','4','8'},
                new char[]{'1','9','8','3','4','2','5','6','7'},
                new char[]{'8','5','9','7','6','1','4','2','3'},
                new char[]{'4','2','6','8','5','3','7','9','1'},
                new char[]{'7','1','3','9','2','4','8','5','6'},
                new char[]{'9','6','1','5','3','7','2','8','4'},
                new char[]{'2','8','7','4','1','9','6','3','5'},
                new char[]{'3','4','5','2','8','6','1','7','9'},
            };
            Assert.True(testSolved.Length == expected.Length && (Enumerable.Range(0, testSolved.Length).All(i => Enumerable.SequenceEqual(testSolved[i], expected[i]))));
        }
        [Test]
        public void SudokuSolverCheck2()
        {
            char[][] test = new char[][]
            {
                new char[]{'.', '.', '9', '7', '4', '8', '.', '.', '.'},
                new char[]{'7', '.', '.', '.', '.', '.', '.', '.', '.'},
                new char[]{'.', '2', '.', '1', '.', '9', '.', '.', '.'},
                new char[]{'.', '.', '7', '.', '.', '.', '2', '4', '.'},
                new char[]{'.', '6', '4', '.', '1', '.', '5', '9', '.'},
                new char[]{'.', '9', '8', '.', '.', '.', '3', '.', '.'},
                new char[]{'.', '.', '.', '8', '.', '3', '.', '2', '.'},
                new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '6'},
                new char[]{'.', '.', '.', '2', '7', '5', '9', '.', '.'}
            };
            char[][] testSolved = SudokuSolver.SolveSudoku(test);
            char[][] expected = new char[][]
            {
                new char[]{'5', '1', '9', '7', '4', '8', '6', '3', '2'},
                new char[]{'7', '8', '3', '6', '5', '2', '4', '1', '9'},
                new char[]{'4', '2', '6', '1', '3', '9', '8', '7', '5'},
                new char[]{'3', '5', '7', '9', '8', '6', '2', '4', '1'},
                new char[]{'2', '6', '4', '3', '1', '7', '5', '9', '8'},
                new char[]{'1', '9', '8', '5', '2', '4', '3', '6', '7'},
                new char[]{'9', '7', '5', '8', '6', '3', '1', '2', '4'},
                new char[]{'8', '3', '2', '4', '9', '1', '7', '5', '6'},
                new char[]{'6', '4', '1', '2', '7', '5', '9', '8', '3'}
            };
            Assert.True(testSolved.Length == expected.Length && (Enumerable.Range(0, testSolved.Length).All(i => Enumerable.SequenceEqual(testSolved[i], expected[i]))));
        }

        [Test]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 3, new int[] {2, 2})]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
        [TestCase(new int[] { }, 0, new int[] { -1, -1 })]
        public void FirstLastPositionCheck(int[] input, int target, int[] expected)
        {
            Assert.True(Enumerable.SequenceEqual(FirstLastPosition.SearchRange(input, target), expected));
        }

        [Test]
        [TestCase(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new int[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
        [TestCase(new int[] { 30, 40, 50, 60 }, new int[] { 1, 1, 1, 0 })]
        [TestCase(new int[] { 30, 60, 90 }, new int[] { 1, 1, 0 })]
        [TestCase(new int[] { 90, 60, 30 }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void DailyTemperatureCheck(int[] input, int[] expected)
        {
            Assert.True(Enumerable.SequenceEqual(DailyTemperature.DailyTemperatures(input), expected));
        }

        [Test]
        [TestCase(new int[] { 4, 3, 2, 1, 4 }, 16)]
        [TestCase(new int[] { 1, 1 }, 1)]
        [TestCase(new int[] { 1, 2, 1 }, 2)]
        [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [TestCase(new int[] { 0, 0}, 0)]
        [TestCase(new int[] { 2, 3, 3, 2 }, 6)]
        [TestCase(new int[] { 2, 7, 7, 2 }, 7)]
        [TestCase(new int[] { 2, 1, 12, 12, 1, 2 }, 12)]
        [TestCase(new int[] { 2, 3, 10, 5, 7, 8, 9 }, 36)]
        public void WaterContainerCheck(int[] input, int expected)
        {
            Assert.AreEqual(WaterContainer.MaxArea(input), expected);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2})]
        [TestCase(new int[] { 1, 2, 4, 8 }, new int[] { 1, 2, 4, 8 })]
        [TestCase(new int[] { 5, 6, 7, 35 }, new int[] { 5, 35 })]
        [TestCase(new int[] { 2, 3 }, new int[] { 2 })]
        [TestCase(new int[] { 2, 3, 4, 9, 8 }, new int[] { 2, 4, 8 })]
        public void LargestDivisibleSubsetCheck(int[] input, int[] expected)
        {
            Assert.True(Enumerable.SequenceEqual(LargestDivisibleSub.LargestDivisibleSubset(input), expected));
        }
    }
}