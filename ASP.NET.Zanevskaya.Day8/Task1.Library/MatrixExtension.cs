using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs, Func<dynamic, dynamic, dynamic> func)
        {
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException("rhs");
            if (lhs.Size != rhs.Size)
                throw new ArgumentException("Different size");
            SquareMatrix<T> squareMatrix = new SquareMatrix<T>(lhs.Size);
            try
            {
                for (int i = 0; i < lhs.Size; i++)
                {
                    for (int j = 0; j < lhs.Size; j++)
                    {
                        squareMatrix[i, j] = func(lhs[i, j], rhs[i, j]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("can't Sum {0}", ex);
            }
            return squareMatrix;
        }
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            return Sum<T>(lhs, rhs, Add<T>);
        }
        private static dynamic Add<T>(dynamic x, dynamic y)
        {
            return (T)(x + y);
        }
    }
}
