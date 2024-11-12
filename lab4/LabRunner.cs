using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1;
using lab2;
using lab3;

namespace lab4
{
    internal class LabRunner
    {
        public void RunLab1(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                lab1.Program.ValidateInput(lines); // Виклик існуючого методу для перевірки
                string result = lab1.Program.ProcessLines(lines); // Обробка даних

                File.WriteAllText(outputFile, result.Trim()); // Запис результату в файл

                Console.WriteLine("File OUTPUT.TXT successfully created");
                Console.WriteLine("LAB #1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RunLab2(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                int result = lab2.Program.CalculateMinimumSpanningTree(inputFile); // Обробка даних

                File.WriteAllText(outputFile, result.ToString().Trim()); // Запис результату в файл

                Console.WriteLine("File OUTPUT.TXT successfully created");
                Console.WriteLine("LAB #1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.ToString().Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void RunLab3(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                char[,] board = lab3.Program.LoadBoard(inputFile);

                (List<(int, int)> whiteCanTake, List<(int, int)> blackCanTake) = lab3.Program.FindTakes(board);
                lab3.Program.WriteOutput(inputFile, whiteCanTake, blackCanTake);

                
                Console.WriteLine("File OUTPUT.TXT successfully created");
                Console.WriteLine("LAB #1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());

                Console.WriteLine("\nOutput data:");
                lab3.Program.DisplayResults(whiteCanTake, blackCanTake);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
