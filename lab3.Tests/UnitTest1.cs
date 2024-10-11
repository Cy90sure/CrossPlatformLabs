using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace lab3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_LoadBoard_ValidInput()
        {
            string[] boardLines = {
                "........",
                "........",
                "........",
                "..B.....",
                "....W...",
                "........",
                "........",
                "........"
            };
            string inputFilePath = "test_input.txt";
            File.WriteAllLines(inputFilePath, boardLines);

            char[,] board = Program.LoadBoard(inputFilePath);

            Assert.Equal('B', board[3, 2]);
            Assert.Equal('W', board[4, 4]);
            Assert.Equal('.', board[0, 0]);
        }

        [Fact]
        public void Test_FindTakes_WhiteCanTake()
        {
            char[,] board = {
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', 'B', '.', '.', '.', '.' },
                { '.', '.', 'W', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' }
            };

            var (whiteCanTake, blackCanTake) = Program.FindTakes(board);

            Assert.Single(whiteCanTake);
            Assert.Contains((2, 3), whiteCanTake);
        }

        [Fact]
        public void Test_FindTakes_BlackCanTake()
        {
            char[,] board = {
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', 'W', '.', '.', '.', '.', '.' },
                { '.', '.', '.', 'B', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' }
            };

            var (whiteCanTake, blackCanTake) = Program.FindTakes(board);

            Assert.Single(blackCanTake);
            Assert.Contains((2, 2), blackCanTake);
        }

        [Fact]
        public void Test_WriteOutput_ValidOutput()
        {
            List<(int, int)> whiteCanTake = new List<(int, int)> { (2, 3) };
            List<(int, int)> blackCanTake = new List<(int, int)> { (3, 2) };
            string outputFilePath = "test_output.txt";

            Program.WriteOutput(outputFilePath, whiteCanTake, blackCanTake);
            string[] outputLines = File.ReadAllLines(outputFilePath);

            Assert.Equal("White: 1", outputLines[0]);
            Assert.Equal("(3, 4)", outputLines[1]);
            Assert.Equal("Black: 1", outputLines[2]);
            Assert.Equal("(4, 3)", outputLines[3]);
        }

        [Fact]
        public void Test_NoCaptures()
        {
            char[,] board = {
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.' }
            };

            var (whiteCanTake, blackCanTake) = Program.FindTakes(board);

            Assert.Empty(whiteCanTake);
            Assert.Empty(blackCanTake);
        }
    }
}
