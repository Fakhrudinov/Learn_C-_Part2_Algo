using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ6_Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ6_Graph.Tests
{
    [TestClass()]
    public class EdgeTests
    {
        [TestMethod()]
        public void PrintNodesBFS_Test_LineFromEnd()
        {
            // [A]--[B]--[C]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);

            Dictionary<string, int> expectedBFS = new Dictionary<string, int>{
                {"A", 1},
                {"B", 2},
                {"C", 3}
            };
            Dictionary<string, int> actualBFS = Edge.PrintNodesBFS(nodaA);

            CollectionAssert.AreEqual(actualBFS, expectedBFS);

            //Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);
            //Вывод узлов графа алгоритмом DFS,
            //стартовый узел A
            //{"A", 1},
            //{"B", 2},
            //{"C", 3},
        }

        [TestMethod()]
        public void PrintNodesBFS_Test_LineFromMiddle()
        {
            //       *
            // [A]--[B]--[C]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Dictionary<string, int> expectedBFS = new Dictionary<string, int>{
                {"B", 1},
                {"A", 2},
                {"C", 2}
            };

            Dictionary<string, int> actualBFS = Edge.PrintNodesBFS(nodaB);

            CollectionAssert.AreEqual(actualBFS, expectedBFS);
            //Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaB);
            //Вывод узлов графа алгоритмом DFS,
            //стартовый узел B
            //{"B", 1},
            //{"C", 2},
            //{"A", 3},
        }

        [TestMethod()]
        public void PrintNodesBFS_Test_Square()
        {
            // [A]--[B]--[C]
            // [D]       [E]
            // [F]--[G]--[H]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaH = new Node("H");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaF, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Edge.AddEdge(nodaG, nodaH, 3);
            Edge.AddEdge(nodaC, nodaE, 3);
            Edge.AddEdge(nodaE, nodaH, 3);

            Dictionary<string, int> expectedBFS = new Dictionary<string, int>
            {
                {"A", 1},
                {"B", 2},
                {"D", 2},
                {"C", 3},
                {"F", 3},
                {"E", 4},
                {"G", 4},
                {"H", 5},
            };
            Dictionary<string, int> actualBFS = Edge.PrintNodesBFS(nodaA);

            CollectionAssert.AreEqual(actualBFS, expectedBFS);

            //Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);
            //Вывод узлов графа алгоритмом DFS,
            //стартовый узел A
            //{"A", 1},
            //{"D", 2},
            //{"F", 3},
            //{"G", 4},
            //{"H", 5},
            //{"E", 6},
            //{"C", 7},
            //{"B", 8},

        }

        [TestMethod()]
        public void PrintNodesBFS_Test_DoubleSquare()
        {
            // [A]--[B]--[C]
            // [D]  [E]  [F]
            // [H]--[I]--[G]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaH = new Node("H");
            Node nodaI = new Node("I");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Edge.AddEdge(nodaB, nodaE, 3);
            Edge.AddEdge(nodaE, nodaI, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaH, 3);
            Edge.AddEdge(nodaH, nodaI, 3);
            Edge.AddEdge(nodaI, nodaG, 3);
            Edge.AddEdge(nodaC, nodaF, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Dictionary<string, int> expectedBFS = new Dictionary<string, int>
            {
                {"A", 1},
                {"B", 2},
                {"D", 2},
                {"C", 3},
                {"E", 3},
                {"H", 3},
                {"F", 4},
                {"I", 4},
                {"G", 5},
            };

            Dictionary<string, int> actualBFS = Edge.PrintNodesBFS(nodaA);

            CollectionAssert.AreEqual(actualBFS, expectedBFS);
            //Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);
            //Вывод узлов графа алгоритмом DFS,
            //стартовый узел A
            //{"A", 1},
            //{"D", 2},
            //{"H", 3},
            //{"I", 4},
            //{"G", 5},
            //{"F", 6},
            //{"C", 7},
            //{"B", 8},
            //{"E", 9},

        }


        [TestMethod()]
        public void PrintNodesBFS_Test_SandClock()
        {
            // [A]--[B]\   /[J]--[L]
            // [D]      [E]      [M]
            // [F]--[G]/   \[K]--[N]

            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaJ = new Node("J");
            Node nodaL = new Node("L");
            Node nodaM = new Node("M");
            Node nodaK = new Node("K");
            Node nodaN = new Node("N");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaE, 3);
            Edge.AddEdge(nodaE, nodaJ, 3);
            Edge.AddEdge(nodaJ, nodaL, 3);
            Edge.AddEdge(nodaL, nodaM, 3);
            Edge.AddEdge(nodaM, nodaN, 3);
            Edge.AddEdge(nodaN, nodaK, 3);
            Edge.AddEdge(nodaE, nodaK, 3);
            Edge.AddEdge(nodaE, nodaG, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaF, 3);

            Dictionary<string, int> expectedBFS = new Dictionary<string, int>
            {
                {"A", 1},
                {"B", 2},
                {"D", 2},
                {"E", 3},
                {"F", 3},
                {"J", 4},
                {"K", 4},
                {"G", 4},
                {"L", 5},
                {"N", 5},
                {"M", 6},
            };

            Dictionary<string, int> actualBFS = Edge.PrintNodesBFS(nodaA);

            CollectionAssert.AreEqual(actualBFS, expectedBFS);
            //Вывод узлов графа алгоритмом DFS,
            //стартовый узел A
            //{"A", 1},
            //{"D", 2},
            //{"F", 3},
            //{"G", 4},
            //{"E", 5},
            //{"K", 6},
            //{"N", 7},
            //{"M", 8},
            //{"L", 9},
            //{"J", 10},
            //{"B", 11},
        }




        [TestMethod()]
        public void PrintNodesDFS_Test_LineFromEnd()
        {
            // [A]--[B]--[C]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);

            Dictionary<string, int> expectedDFS = new Dictionary<string, int>{
                {"A", 1},
                {"B", 2},
                {"C", 3},
            };
            Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);

            CollectionAssert.AreEqual(actualDFS, expectedDFS);
        }

        [TestMethod()]
        public void PrintNodesDFS_Test_LineFromMiddle()
        {
            //       *
            // [A]--[B]--[C]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Dictionary<string, int> expectedDFS = new Dictionary<string, int>{
                {"B", 1},
                {"C", 2},
                {"A", 3},
            };

            Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaB);

            CollectionAssert.AreEqual(actualDFS, expectedDFS);
        }

        [TestMethod()]
        public void PrintNodesDFS_Test_Square()
        {
            // [A]--[B]--[C]
            // [D]       [E]
            // [F]--[G]--[H]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaH = new Node("H");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaF, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Edge.AddEdge(nodaG, nodaH, 3);
            Edge.AddEdge(nodaC, nodaE, 3);
            Edge.AddEdge(nodaE, nodaH, 3);

            Dictionary<string, int> expectedDFS = new Dictionary<string, int>{
                {"A", 1},
                {"D", 2},
                {"F", 3},
                {"G", 4},
                {"H", 5},
                {"E", 6},
                {"C", 7},
                {"B", 8},
            };
            Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);

            CollectionAssert.AreEqual(actualDFS, expectedDFS);
        }

        [TestMethod()]
        public void PrintNodesDFS_Test_DoubleSquare()
        {
            // [A]--[B]--[C]
            // [D]  [E]  [F]
            // [H]--[I]--[G]
            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaH = new Node("H");
            Node nodaI = new Node("I");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaC, 3);
            Edge.AddEdge(nodaB, nodaE, 3);
            Edge.AddEdge(nodaE, nodaI, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaH, 3);
            Edge.AddEdge(nodaH, nodaI, 3);
            Edge.AddEdge(nodaI, nodaG, 3);
            Edge.AddEdge(nodaC, nodaF, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Dictionary<string, int> expectedDFS = new Dictionary<string, int>{
                {"A", 1},
                {"D", 2},
                {"H", 3},
                {"I", 4},
                {"G", 5},
                {"F", 6},
                {"C", 7},
                {"B", 8},
                {"E", 9},
            };

            Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);

            CollectionAssert.AreEqual(actualDFS, expectedDFS);
        }

        [TestMethod()]
        public void PrintNodesDFS_Test_SandClock()
        {
            // [A]--[B]\   /[J]--[L]
            // [D]      [E]      [M]
            // [F]--[G]/   \[K]--[N]

            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaJ = new Node("J");
            Node nodaL = new Node("L");
            Node nodaM = new Node("M");
            Node nodaK = new Node("K");
            Node nodaN = new Node("N");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaB, nodaE, 3);
            Edge.AddEdge(nodaE, nodaJ, 3);
            Edge.AddEdge(nodaJ, nodaL, 3);
            Edge.AddEdge(nodaL, nodaM, 3);
            Edge.AddEdge(nodaM, nodaN, 3);
            Edge.AddEdge(nodaN, nodaK, 3);
            Edge.AddEdge(nodaE, nodaK, 3);
            Edge.AddEdge(nodaE, nodaG, 3);
            Edge.AddEdge(nodaF, nodaG, 3);
            Edge.AddEdge(nodaA, nodaD, 3);
            Edge.AddEdge(nodaD, nodaF, 3);

            Dictionary<string, int> expectedDFS = new Dictionary<string, int>{
                {"A", 1},
                {"D", 2},
                {"F", 3},
                {"G", 4},
                {"E", 5},
                {"K", 6},
                {"N", 7},
                {"M", 8},
                {"L", 9},
                {"J", 10},
                {"B", 11},
            };

            Dictionary<string, int> actualDFS = Edge.PrintNodesDFS(nodaA);

            CollectionAssert.AreEqual(actualDFS, expectedDFS);
        }
    }
}