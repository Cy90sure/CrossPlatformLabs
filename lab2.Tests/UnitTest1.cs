using System;
using System.Collections.Generic;
using Xunit;
using lab2;

namespace lab2.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestCalculateMinimumSpanningTree_WithSimpleInput()
        {
            var nails = new[] { 1, 3, 4, 5 };
            var expectedLength = 4;

            var edges = CreateEdges(nails);
            var actualLength = Program.Kruskal(nails.Length, edges);

            Assert.Equal(expectedLength, actualLength);
        }

        [Fact]
        public void TestKruskal_WithNoEdges()
        {
            var edges = new List<Program.Edge>();
            var expectedLength = 0;

            var actualLength = Program.Kruskal(0, edges);

            Assert.Equal(expectedLength, actualLength);
        }

        [Fact]
        public void TestKruskal_WithOneEdge()
        {
            var edges = new List<Program.Edge>
            {
                new Program.Edge(5, 0, 1) 
            };
            var expectedLength = 5;

            var actualLength = Program.Kruskal(2, edges);

            Assert.Equal(expectedLength, actualLength);
        }

        [Fact]
        public void TestFind_WithSameRoot()
        {
            var parent = new[] { 0, 0, 2, 3 };
            var expectedRoot = 0;

            var actualRoot = Program.Find(1, parent);

            Assert.Equal(expectedRoot, actualRoot);
        }

        [Fact]
        public void TestUnion_WithDifferentRoots()
        {
            var parent = new[] { 0, 1, 2, 3 };
            var rank = new[] { 1, 0, 0, 0 };
            var u = 0;
            var v = 1;

            Program.Union(u, v, parent, rank);

            Assert.Equal(0, parent[1]);
        }

        private List<Program.Edge> CreateEdges(int[] nails)
        {
            var edges = new List<Program.Edge>();
            for (int i = 0; i < nails.Length; i++)
            {
                for (int j = i + 1; j < nails.Length; j++)
                {
                    int distance = Math.Abs(nails[i] - nails[j]);
                    edges.Add(new Program.Edge(distance, i, j));
                }
            }
            edges.Sort();
            return edges;
        }
    }
}
