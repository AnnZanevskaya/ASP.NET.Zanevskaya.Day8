using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Library;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matr1 = { { 1, 2, 3 }, 
                            { 1, 2, 3 }, 
                            { 1, 2, 3 } };
            SquareMatrix<int> matrix1 = new SquareMatrix<int>(matr1);

            int[,] matr2 = { { 1, 0, 0 }, 
                            { 0, 2, 0 }, 
                            { 0, 0, 3 } };
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(matr2);

            int[,] matr3 = { { 1, 5, 3 }, 
                            { 5, 2, 7 }, 
                            { 3, 7, 3 } };
            SymmetricMatrix<int> matrix3 = new SymmetricMatrix<int>(matr3);

            var squar = new Listeners<int>();
            squar.Register(matrix1);
            squar.Register(matrix2);
            squar.Register(matrix3);

             matrix1[1, 2] = 3;
             matrix2[2, 2] = 3;
             matrix3[1, 0] = 3;


             SquareMatrix<int> output = matrix1.Sum(matrix2, (x, y) => x + y);
             SquareMatrix<int> output2 = matrix1.Sum(matrix2);
             Console.WriteLine();
            }
    }
}
