using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class ValidSudoku
    {
        public static bool IsValidSudoku(char[][] board)
        {
            // Check if inner 3x3 squares are valid 
            for (int i = 0; i < board.Length/3; i++)
                for (int j = 0; j < board[i].Length/3; j++)
                {
                    HashSet<char> set = new HashSet<char>();
                    for (int k = 0; k < 3; ++k)
                        for (int l = 0; l < 3; ++l)
                            if (board[3 * i + k][3 * j + l] != '.')
                                if (!set.Add(board[3 * i + k][3 * j + l]))
                                    return false;
                }
            // Check if inner rows are valid 
            for (int i = 0; i < board.Length; i++)
            {
                HashSet<char> set = new HashSet<char>();
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] != '.')
                        if (!set.Add(board[i][j]))
                            return false;
                }
            }
            // Check if inner columns are valid 
            for (int i = 0; i < board.Length; i++)
            {
                HashSet<char> set = new HashSet<char>();
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[j][i] != '.')
                        if (!set.Add(board[j][i]))
                            return false;
                }
            }

            return true;
        }
    }
}
