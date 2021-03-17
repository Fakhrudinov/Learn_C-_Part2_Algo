using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ7;
using System;
using System.Collections.Generic;
using System.Text;

namespace DZ7.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetSimpleMoveArrayTest_LineGorizontal()
        {
            int[,] ExpectedValues = new int[1, 3]
            {
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArray(ExpectedValues.GetLength(0), ExpectedValues.GetLength(1));

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayTest_LineVertical()
        {
            int[,] ExpectedValues = new int[3, 1]
            {
               { 1 },
               { 1 },
               { 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArray(ExpectedValues.GetLength(0), ExpectedValues.GetLength(1));

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayTest_Cube3x3()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 2, 3 },
               { 1, 3, 6 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArray(ExpectedValues.GetLength(0), ExpectedValues.GetLength(1));

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayTest_Rectangle3x5()
        {
            int[,] ExpectedValues = new int[3, 5]
            {
               { 1, 1, 1, 1, 1 },
               { 1, 2, 3, 4, 5 },
               { 1, 3, 6, 10, 15 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArray(ExpectedValues.GetLength(0), ExpectedValues.GetLength(1));

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_LineVerticalFree()
        {
            int[,] ExpectedValues = new int[1, 3]
            {
               { 1, 1, 1 }
            };

            int[,] Blocked = new int[1, 3] // все ходы доступны
            {
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_LineHorizontalFree()
        {
            int[,] ExpectedValues = new int[3, 1]
            {
               { 1 },
               { 1 },
               { 1 }
            };

            int[,] Blocked = new int[3, 1] // все ходы доступны
            {
               { 1 },
               { 1 },
               { 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_LineVerticalBlocked()
        {
            int[,] ExpectedValues = new int[1, 3]
            {
               { 1, 0, 0 }
            };

            int[,] Blocked = new int[1, 3] 
            {
               { 1, 0, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_LineHorizontalBlocked()
        {
            int[,] ExpectedValues = new int[3, 1]
            {
               { 1 },
               { 0 },
               { 0 }
            };

            int[,] Blocked = new int[3, 1] 
            {
               { 1 },
               { 0 },
               { 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeFree()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 2, 3 },
               { 1, 3, 6 }
            };

            int[,] Blocked = new int[3, 3] // все ходы доступны
            {
               { 1, 1, 1 },
               { 1, 1, 1 },
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedTop()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 0, 0 },
               { 1, 1, 1 },
               { 1, 2, 3 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 0, 1 },
               { 1, 1, 1 },
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedLeft()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 0, 1, 2 },
               { 0, 1, 3 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 1, 1 },
               { 0, 1, 1 },
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedMiddle()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 0, 1 },
               { 1, 1, 2 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 0, 1 },
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedRight()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 2, 0 },
               { 1, 3, 3 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 1, 0 },
               { 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }


        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedBottom()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 2, 3 },
               { 1, 0, 3 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 1, 1 },
               { 1, 0, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_CubeBlockedBottomAndRight()
        {
            int[,] ExpectedValues = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 2, 0 },
               { 1, 0, 0 }
            };

            int[,] Blocked = new int[3, 3]
            {
               { 1, 1, 1 },
               { 1, 1, 0 },
               { 1, 0, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }

        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_Rectangle4x4()
        {
            int[,] ExpectedValues = new int[4, 4]
            {
               { 1, 1, 0, 0 },
               { 1, 2, 2, 2 },
               { 1, 0, 2, 4 },
               { 1, 1, 3, 7 },
            };

            int[,] Blocked = new int[4, 4]
            {
               { 1, 1, 0, 1 },
               { 1, 1, 1, 1 },
               { 1, 0, 1, 1 },
               { 1, 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }


        [TestMethod()]
        public void GetSimpleMoveArrayWithBlockTest_Rectangle5x5()
        {
            int[,] ExpectedValues = new int[5, 5]
            {
               { 1, 1, 1, 1, 1 },
               { 1, 2, 0, 1, 2 },
               { 1, 3, 3, 4, 6 },
               { 1, 0, 3, 7, 13 },
               { 1, 1, 4, 11, 24 }
            };

            int[,] Blocked = new int[5, 5]
            {
               { 1, 1, 1, 1, 1 },
               { 1, 1, 0, 1, 1 },
               { 1, 1, 1, 1, 1 },
               { 1, 0, 1, 1, 1 },
               { 1, 1, 1, 1, 1 }
            };

            int[,] ActualValues = Program.GetSimpleMoveArrayWithBlock(Blocked);

            CollectionAssert.AreEqual(ExpectedValues, ActualValues);
        }
    }
}