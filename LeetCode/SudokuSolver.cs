using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal static class SudokuSolver
    {
        private static char defaultValue = '.';
        public static char[][] SolveSudokuBruteForce(char[][] board)
        {
            int nonEmptyCellsTotal = 0;
            while (nonEmptyCellsTotal < board.Length * board.Length)
            {
                int nonEmptyCells = 0;
                for (int i = 0; i < board.Length; i++)
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            HashSet<char> options = CellOptions(board, i, j);
                            if (options.Count == 1)
                            {
                                board[i][j] = options.First();
                                nonEmptyCells++;
                            }
                        }
                        else
                            nonEmptyCells++;
                    }
                nonEmptyCellsTotal = nonEmptyCells;
            }
            return board;
        }
        public static char[][] SolveSudoku(char[][] board)
        {
            // Initialize jagged array of hashsets to store board variants
            HashSet<char>[][] boardVariants = new HashSet<char>[board.Length][];
            for (int i = 0; i < board.Length; i++)
                boardVariants[i] = new HashSet<char>[board.Length];

            // A queue to store cells that are going to impact other cells
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();

            // Initial run to collect every possible table state
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        boardVariants[i][j] = CellOptions(board, i, j);
                        if (boardVariants[i][j].Count == 1)
                        {
                            board[i][j] = boardVariants[i][j].First();
                            queue.Enqueue(new Tuple<int, int>(i, j));
                        }
                    }
                    else
                    {
                        boardVariants[i][j] = new HashSet<char> { board[i][j] };
                        visited.Add(new Tuple<int, int>(i, j));
                    }
                }


            while (queue.Count > 0)
            //while (visited.Count < board.Length * board.Length)
            {
                while (queue.Count > 0)
                {
                    Tuple<int, int> top = queue.Dequeue();
                    RemoveOptionsInRow(queue, visited, boardVariants, board, top.Item1, top.Item2);
                    RemoveOptionsInColumn(queue, visited, boardVariants, board, top.Item1, top.Item2);
                    RemoveOptionsInSquare(queue, visited, boardVariants, board, top.Item1, top.Item2);
                    visited.Add(top);
                }

                Console.WriteLine(visited.Count);

                bool onlyPossibleValueFound = false;

                // Go through options in each square
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board.Length; j++)
                        if (board[i][j] == '.')
                        {
                            char onlyPossibleValue = '.';
                            char onlyPossibleValueBasedOnSquare = CellOptionsSquareExclude(queue, visited, boardVariants, board, i, j);

                            if (onlyPossibleValueBasedOnSquare != '.')
                                onlyPossibleValue = onlyPossibleValueBasedOnSquare;
                            else
                            {
                                char onlyPossibleValueBasedOnRow = CellOptionsRowExclude(queue, visited, boardVariants, board, i, j);
                                if (onlyPossibleValueBasedOnRow != '.')
                                    onlyPossibleValue = onlyPossibleValueBasedOnRow;
                                else
                                {
                                    onlyPossibleValue = CellOptionsColumnExclude(queue, visited, boardVariants, board, i, j);
                                }
                            }
                            if (onlyPossibleValue != '.')
                            {
                                board[i][j] = onlyPossibleValue;
                                boardVariants[i][j] = new HashSet<char> { onlyPossibleValue };
                                if (!visited.Contains(new Tuple<int, int>(i, j)))
                                    queue.Enqueue(new Tuple<int, int>(i, j));
                                visited.Add(new Tuple<int, int>(i, j));
                                onlyPossibleValueFound = true;
                                break;
                            }

                        }
                    if (onlyPossibleValueFound)
                        break;
                }
            }

            return board;
        }

        public static HashSet<char> CellOptions(char[][] board, int i, int j)
        {
            // Creating an array of digit chars: 
            HashSet<char> options = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            //List<char> options = Enumerable.Range(1, board.Length).ToList().Select(x => (char)(x + 48)).ToList();

            /*RemoveCellOptionsBasedOnRow(options, board, i);
            RemoveCellOptionsBasedOnColumn(options, board, i);
            RemoveCellOptionsBasedOnSquare(options, board, i, j);*/

            // Check respective row to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (board[i][k] != '.')
                    options.Remove(board[i][k]);

            // Check respective column to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (board[k][j] != '.')
                    options.Remove(board[k][j]);

            // Check respective square to eliminate value options
            for (int k = 0; k < 3; k++)
                for (int l = 0; l < 3; l++)
                    if (board[(i / 3) * 3 + k][(j / 3) * 3 + l] != '.')
                        options.Remove(board[(i / 3) * 3 + k][(j / 3) * 3 + l]);

            return options;
        }

        public static char CellOptionsSquareExclude(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            char onlyPossibleValue = '.';
            foreach (char c in boardVariants[i][j])
            {
                bool someOtherContainsC = false; 
                for (int k = 0; k < 3; k++)
                    for (int l = 0; l < 3; l++)
                    {
                        int sqi = (i / 3) * 3 + k;
                        int sqj = (j / 3) * 3 + l;
                        if (!((sqi == i) && (sqj == j)))
                        {
                            if (boardVariants[sqi][sqj].Contains(c))
                            {
                                someOtherContainsC = true;
                                break;
                            }
                        }
                    }
                if (!someOtherContainsC)
                {
                    onlyPossibleValue = c;
                    break;
                }
            }

            return onlyPossibleValue;
        }

        public static char CellOptionsRowExclude(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            char onlyPossibleValue = '.';
            foreach (char c in boardVariants[i][j])
            {
                bool someOtherContainsC = false;
                for (int k = 0; k < board.Length; k++)
                    {
                        if (k != j)
                        {
                            if (boardVariants[i][k].Contains(c))
                            {
                                someOtherContainsC = true;
                                break;
                            }
                        }
                    }
                if (!someOtherContainsC)
                {
                    onlyPossibleValue = c;
                    break;
                }
            }

            return onlyPossibleValue;
        }

        public static char CellOptionsColumnExclude(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            char onlyPossibleValue = '.';
            foreach (char c in boardVariants[i][j])
            {
                bool someOtherContainsC = false;
                for (int k = 0; k < board.Length; k++)
                {
                    if (k != i)
                    {
                        if (boardVariants[k][j].Contains(c))
                        {
                            someOtherContainsC = true;
                            break;
                        }
                    }
                }
                if (!someOtherContainsC)
                {
                    onlyPossibleValue = c;
                    break;
                }
            }

            return onlyPossibleValue;
        }

        public static void RemoveOptionsInRow(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            // Go through respective row to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (k != j)
                {
                    boardVariants[i][k].Remove(board[i][j]);
                    Tuple<int, int> indexTuple = new Tuple<int, int>(i, k);
                    if (boardVariants[i][k].Count == 1 && !queue.Contains(indexTuple) && !visited.Contains(indexTuple))
                    {
                        board[i][k] = boardVariants[i][k].First();
                        queue.Enqueue(indexTuple);
                        visited.Add(indexTuple);
                        RemoveOptionsInColumn(queue, visited, boardVariants, board, i, k);
                        RemoveOptionsInSquare(queue, visited, boardVariants, board, i, k);
                    }
                }
        }

        public static void RemoveOptionsInColumn(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            // Go through respective column to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (k != i)
                {
                    boardVariants[k][j].Remove(board[i][j]);
                    Tuple<int, int> indexTuple = new Tuple<int, int>(k, j);
                    if (boardVariants[k][j].Count == 1 && !queue.Contains(indexTuple) && !visited.Contains(indexTuple))
                    {
                        board[k][j] = boardVariants[k][j].First();
                        queue.Enqueue(indexTuple);
                        visited.Add(indexTuple);
                        RemoveOptionsInRow(queue, visited, boardVariants, board, k, j);
                        RemoveOptionsInSquare(queue, visited, boardVariants, board, k, j);
                    }
                }
        }

        public static void RemoveOptionsInSquare(Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> visited, HashSet<char>[][] boardVariants, char[][] board, int i, int j)
        {
            // Go through respective square to eliminate value options
            for (int k = 0; k < 3; k++)
                for (int l = 0; l < 3; l++)
                {
                    int sqi = (i / 3) * 3 + k;
                    int sqj = (j / 3) * 3 + l;
                    if ((sqi != i) && (sqj != j))
                    {
                        boardVariants[sqi][sqj].Remove(board[i][j]);
                        Tuple<int, int> indexTuple = new Tuple<int, int>(sqi, sqj);
                        if (boardVariants[sqi][sqj].Count == 1 && !queue.Contains(indexTuple) && !visited.Contains(indexTuple))
                        {
                            board[sqi][sqj] = boardVariants[sqi][sqj].First();
                            queue.Enqueue(indexTuple);
                            visited.Add(indexTuple);
                            RemoveOptionsInRow(queue, visited, boardVariants, board, sqi, sqj);
                            RemoveOptionsInColumn(queue, visited, boardVariants, board, sqi, sqj);
                        }
                    }

                }
        }

        /*public static void RemoveCellOptionsBasedOnRow(HashSet<char> options, char[][] board, int i)
        {
            // Check respective row to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (board[i][k] != '.')
                    options.Remove(board[i][k]);
        }

        public static void RemoveCellOptionsBasedOnColumn(HashSet<char> options, char[][] board, int j)
        {
            // Check respective column to eliminate value options
            for (int k = 0; k < board.Length; k++)
                if (board[k][j] != '.')
                    options.Remove(board[k][j]);
        }

        public static void RemoveCellOptionsBasedOnSquare(HashSet<char> options, char[][] board, int i, int j)
        {
            // Check respective square to eliminate value options
            for (int k = 0; k < 3; k++)
                for (int l = 0; l < 3; l++)
                    if (board[(i / 3) * 3 + k][(j / 3) * 3 + l] != '.')
                        options.Remove(board[(i / 3) * 3 + k][(j / 3) * 3 + l]);
        }*/
    }
}
