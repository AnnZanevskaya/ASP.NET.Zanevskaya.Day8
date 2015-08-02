using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SquareMatrix_Create_Test()
        {
            int[,] matr = { { 1, 2, 3 }, 
                            { 1, 2, 3 }, 
                            { 1, 2, 3 } };
            SquareMatrix<int> matrix = new SquareMatrix<int>(matr);
            Assert.AreEqual(3, matrix[2, 2]);
        }
        [TestMethod]
        public void SquareMatrix_SetValue_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            matrix[1, 2] = 3;
            Assert.AreEqual(3, matrix[1, 2]);
        }
        [TestMethod]
        public void DiagonalMatrix_Create_Test()
        {
            int[,] matr = { { 1, 0, 0 }, 
                            { 0, 2, 0 }, 
                            { 0, 0, 3 } };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(matr);
            Assert.AreEqual(3, matrix[2, 2]);
        }
        [TestMethod]
        public void DiagonalMatrix_SetValue_Test()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3);
            matrix[2, 2] = 3;
            Assert.AreEqual(3, matrix[2, 2]);
        }
        [TestMethod]
        public void SymmetricMatrix_Create_Test()
        {
            int[,] matr = { { 1, 5, 3 }, 
                            { 5, 2, 7 }, 
                            { 3, 7, 3 } };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(matr);
            Assert.AreEqual(5, matrix[0, 1]);
        }
        [TestMethod]
        public void SymmetricMatrix_SetValue_Test()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3);
            matrix[1, 0] = 3;
            Assert.AreEqual(3, matrix[0, 1]);
        }

    }
}
