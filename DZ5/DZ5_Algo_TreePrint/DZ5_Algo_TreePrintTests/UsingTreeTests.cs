using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ5_Algo_TreePrint;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Algo_TreePrint.Tests
{
    [TestClass()]
    public class UsingTreeTests
    {
        [TestCleanup]
        public void testClean()
        {
            UsingTree delete = new UsingTree();

            int[] del = delete.PrintNodesBFS();
            foreach (int itemToDel in del)
            {
                delete.RemoveItem(itemToDel);
            }
        }

        //BFS-------------------------------------------
        [TestMethod()]
        public void PrintNodesBFSTest_1()
        {
            //  [1]
            //   [3]
            //    [5]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(1, 3, 5);

            int[] expectedResult = new int[] { 1, 3, 5 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesBFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesBFSTest_2()
        {
        //                 [11]
        //               [9]  [13]
        //            [7]        [15]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(11, 9, 13, 7, 15);

            int[] expectedResult = new int[] { 11, 9, 13, 7, 15 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesBFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesBFSTest_3()
        {
        //           ________[100]____
        //       [50]                 [150]
        //   [25]    [75]        [125]    [175]
        //[5]                [105]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(100, 50, 150, 25, 75, 125, 175, 105, 5);

            int[] expectedResult = new int[] { 100, 50, 150, 25, 75, 125, 175, 5, 105 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesBFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesBFSTest_4()
        {
        //     _______[20]________
        // [10]                  [30]
        //    [11]            [29]
        //        [12]     [28]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(20, 10, 30, 11, 29, 12, 28);

            int[] expectedResult = new int[] { 20, 10, 30, 11, 29, 12, 28 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesBFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesBFSTest_5()
        {
        //           _____[20]
        //       [10]
        //    [9]    [11]
        // [8]          [12]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(20, 10, 9, 11, 8, 12);

            int[] expectedResult = new int[] { 20, 10, 9, 11, 8, 12 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesBFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        //DFS-------------------------------------------
        [TestMethod()]
        public void PrintNodesDFSTest_1()
        {
            //  [1]
            //   [3]
            //    [5]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(1, 3, 5);

            int[] expectedResult = new int[] { 1, 3, 5 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesDFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesDFSTest_2()
        {
            //                 [11]
            //               [9]  [13]
            //            [7]        [15]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(11, 9, 13, 7, 15);

            int[] expectedResult = new int[] { 11, 9, 7, 13, 15 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesDFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesDFSTest_3()
        {
            //           ________[100]____
            //       [50]                 [150]
            //   [25]    [75]        [125]    [175]
            //[5]                [105]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(100, 50, 150, 25, 75, 125, 175, 5, 105);

            int[] expectedResult = new int[] { 100, 50, 25, 5, 75, 150, 125, 105, 175 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesDFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesDFSTest_4()
        {
            //     _______[20]________
            // [10]                  [30]
            //    [11]            [29]
            //        [12]     [28]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(20, 10, 30, 11, 29, 12, 28);

            int[] expectedResult = new int[] { 20, 10, 11, 12, 30, 29, 28 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesDFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void PrintNodesDFSTest_5()
        {
            //           _____[20]
            //       [10]
            //    [9]    [11]
            // [8]          [12]

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(20, 10, 9, 11, 8, 12);

            int[] expectedResult = new int[] { 20, 10, 9, 8, 11, 12 };

            UsingTree getNodes = new UsingTree();
            int[] actualResult = getNodes.PrintNodesDFS();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}