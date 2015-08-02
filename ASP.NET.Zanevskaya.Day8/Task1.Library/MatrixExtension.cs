﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs, Func<T, T, T> func)
        {
            if (rhs == null)
                throw new ArgumentNullException();
            if (lhs.Size != rhs.Size)
                throw new ArgumentException("Different size");

            SquareMatrix<T> squareMatrix = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    squareMatrix[i, j] = func(lhs[i, j], rhs[i, j]);
                }
            }
            return squareMatrix;
        }
       
    }
}
