using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("lab2", "INPUT.TXT");
                string outputFilePath = Path.Combine("lab2", "OUTPUT.TXT");

                Console.WriteLine("\nLab2:");
                Console.WriteLine("Input data:");
                var inputLines = File.ReadAllLines(inputFilePath);
                foreach (var line in inputLines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();

                int totalLength = CalculateMinimumSpanningTree(inputLines);

                System.IO.File.WriteAllText(outputFilePath, totalLength.ToString());

                Console.WriteLine($"\nOutput data: {totalLength}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static int CalculateMinimumSpanningTree(string[] lines)
        {
            int n = int.Parse(lines[0]);
            var nails = lines[1].Split(' ').Select(int.Parse).ToArray();

            var edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int distance = Math.Abs(nails[i] - nails[j]);
                    edges.Add(new Edge(distance, i, j));
                }
            }

            edges.Sort();

            return Kruskal(n, edges);
        }

        public static int Kruskal(int n, List<Edge> edges)
        {
            int totalLength = 0;
            var parent = Enumerable.Range(0, n).ToArray();
            var rank = new int[n];

            foreach (var edge in edges)
            {
                int rootU = Find(edge.U, parent);
                int rootV = Find(edge.V, parent);

                if (rootU != rootV)
                {
                    totalLength += edge.Weight;
                    Union(rootU, rootV, parent, rank);
                }
            }

            return totalLength;
        }

        public static int Find(int u, int[] parent)
        {
            if (parent[u] != u)
                parent[u] = Find(parent[u], parent);
            return parent[u];
        }

        public static void Union(int u, int v, int[] parent, int[] rank)
        {
            if (rank[u] > rank[v])
                parent[v] = u;
            else if (rank[u] < rank[v])
                parent[u] = v;
            else
            {
                parent[v] = u;
                rank[u]++;
            }
        }

        public class Edge : IComparable<Edge>
        {
            public int Weight { get; }
            public int U { get; }
            public int V { get; }

            public Edge(int weight, int u, int v)
            {
                Weight = weight;
                U = u;
                V = v;
            }

            public int CompareTo(Edge? other)
            {
                if (other == null) return 1;
                return this.Weight.CompareTo(other.Weight);
            }
        }
    }
}
