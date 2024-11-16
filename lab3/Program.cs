using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab3
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("lab3", "INPUT.TXT");
                string outputFilePath = Path.Combine("lab3", "OUTPUT.TXT");

                string[] lines = File.ReadAllLines(inputFilePath);

                char[,] board = LoadBoard(lines);

                Console.WriteLine("\nLab1:");
                Console.WriteLine("Input Board:");
                PrintBoard(board);

                (List<(int, int)> whiteCanTake, List<(int, int)> blackCanTake) = FindTakes(board);

                string result = WriteOutput(lines, whiteCanTake, blackCanTake);
                File.WriteAllText(outputFilePath, result.Trim());

                Console.WriteLine("\nOutput data:");
                DisplayResults(whiteCanTake, blackCanTake);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static char[,] LoadBoard(string[] lines)
        {
            
            char[,] board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = lines[i][j];
                }
            }

            return board;
        }

        public static (List<(int, int)>, List<(int, int)>) FindTakes(char[,] board)
        {
            var whiteCanTake = new List<(int, int)>();
            var blackCanTake = new List<(int, int)>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 'W')
                    {
                        CheckWhiteTakes(board, i, j, whiteCanTake);
                    }
                    else if (board[i, j] == 'B')
                    {
                        CheckBlackTakes(board, i, j, blackCanTake);
                    }
                }
            }

            return (whiteCanTake, blackCanTake);
        }

        public static void CheckWhiteTakes(char[,] board, int row, int col, List<(int, int)> whiteCanTake)
        {
            int[] dRow = { -1, -1, 1, 1 };
            int[] dCol = { -1, 1, -1, 1 };

            for (int d = 0; d < 4; d++)
            {
                int enemyRow = row + dRow[d];
                int enemyCol = col + dCol[d];
                int afterRow = row + 2 * dRow[d];
                int afterCol = col + 2 * dCol[d];

                if (IsInBounds(enemyRow, enemyCol) && IsInBounds(afterRow, afterCol) && board[enemyRow, enemyCol] == 'B' && board[afterRow, afterCol] == '.')
                {
                    if (!whiteCanTake.Contains((enemyRow, enemyCol)))
                    {
                        whiteCanTake.Add((enemyRow, enemyCol));
                        CheckWhiteTakes(board, afterRow, afterCol, whiteCanTake);
                    }
                }
            }
        }

        public static void CheckBlackTakes(char[,] board, int row, int col, List<(int, int)> blackCanTake)
        {
            int[] dRow = { -1, -1, 1, 1 };
            int[] dCol = { -1, 1, -1, 1 };

            for (int d = 0; d < 4; d++)
            {
                int enemyRow = row + dRow[d];
                int enemyCol = col + dCol[d];
                int afterRow = row + 2 * dRow[d];
                int afterCol = col + 2 * dCol[d];

                if (IsInBounds(enemyRow, enemyCol) && IsInBounds(afterRow, afterCol) && board[enemyRow, enemyCol] == 'W' && board[afterRow, afterCol] == '.')
                {
                    if (!blackCanTake.Contains((enemyRow, enemyCol)))
                    {
                        blackCanTake.Add((enemyRow, enemyCol));
                        CheckBlackTakes(board, afterRow, afterCol, blackCanTake);
                    }
                }
            }
        }

        public static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        public static string WriteOutput(string[] lines, List<(int, int)> whiteCanTake, List<(int, int)> blackCanTake)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"White: {whiteCanTake.Count}\n");

            if (whiteCanTake.Count > 0)
            {
                whiteCanTake.Sort();
                foreach (var pos in whiteCanTake)
                {
                    result.AppendLine($"({pos.Item1 + 1}, {pos.Item2 + 1})\n");
                }
            }

            result.AppendLine($"Black: {blackCanTake.Count}\n");
            if (blackCanTake.Count > 0)
            {
                blackCanTake.Sort();
                foreach (var pos in blackCanTake)
                {
                    result.AppendLine($"({pos.Item1 + 1}, {pos.Item2 + 1})\n");
                }
            }

            return result.ToString();
        }

        public static void DisplayResults(List<(int, int)> whiteCanTake, List<(int, int)> blackCanTake)
        {
            Console.WriteLine($"White: {whiteCanTake.Count}");
            if (whiteCanTake.Count > 0)
            {
                foreach (var pos in whiteCanTake)
                {
                    Console.WriteLine($"({pos.Item1 + 1}, {pos.Item2 + 1})");
                }
            }

            Console.WriteLine($"Black: {blackCanTake.Count}");
            if (blackCanTake.Count > 0)
            {
                foreach (var pos in blackCanTake)
                {
                    Console.WriteLine($"({pos.Item1 + 1}, {pos.Item2 + 1})");
                }
            }
        }

        public static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
