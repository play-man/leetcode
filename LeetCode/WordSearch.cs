using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*Given an m x n grid of characters board and a string word, return true if word exists in the grid.

    The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. 
    The same letter cell may not be used more than once.

    Constraints:

    m == board.length
    n = board[i].length
    1 <= m, n <= 6
    1 <= word.length <= 15
    board and word consists of only lowercase and uppercase English letters.*/
    internal static class WordSearch
    {
        public static bool Exist(char[][] board, string word)
        {
            bool result = false;
            List<Tuple<int, int>> potentialWordBeginning = new List<Tuple<int, int>>();
            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    if (board[i][j] == word[0])
                        potentialWordBeginning.Add(new Tuple<int, int>(i, j));

            foreach (Tuple<int, int> tuple in potentialWordBeginning)
            {
                List<Tuple<int, int>> visited = new List<Tuple<int, int>> { };
                if (ExistStartingFromCell(board, visited, word, tuple.Item1, tuple.Item2, m, n))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool ExistStartingFromCell(char[][] board, List<Tuple<int, int>> visited, string word, int i, int j, int m, int n)
        {
            if (word.Length == 0)
                return true;

            if (visited.Contains(new Tuple<int, int>(i, j)))
                return false;

            if (word[0] != board[i][j])
            {
                visited.Remove(new Tuple<int, int>(i,j));
                return false;
            }

            if (word.Length == 1)
                return true;

            string wordWithoutFirstLetter = word.Substring(1);

            visited.Add(new Tuple<int, int>(i, j));

            List<Tuple<int, int>> visitedTop = new List<Tuple<int, int>>(visited);
            List<Tuple<int, int>> visitedRight = new List<Tuple<int, int>>(visited);
            List<Tuple<int, int>> visitedBottom = new List<Tuple<int, int>>(visited);
            List<Tuple<int, int>> visitedLeft = new List<Tuple<int, int>>(visited);

            bool a = (i == 0) ? false : ExistStartingFromCell(board, visitedTop, wordWithoutFirstLetter, i - 1, j, m, n);
            bool b = a ? a : ((j == n - 1) ? false : ExistStartingFromCell(board, visitedRight, wordWithoutFirstLetter, i, j + 1, m, n));
            bool c = b ? b : ((i == m - 1) ? false : ExistStartingFromCell(board, visitedBottom, wordWithoutFirstLetter, i + 1, j, m, n));
            bool d = c ? c: ((j == 0) ? false : ExistStartingFromCell(board, visitedLeft, wordWithoutFirstLetter, i, j - 1, m, n));

            return d;
        }
    }
}
