using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class DiagonalMatrix<T>: SquareMatrix<T>
    {
        public DiagonalMatrix(int size)
        {
            if (size < 0) throw new ArgumentException("Size is invalid");
            matrix = new T[size];
            Size = size;
        }
        public DiagonalMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException("Matrix is null");
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("Matrix should be square");
            if (!IsDiagonal(matrix))
                throw new ArgumentException("Matrix isn't diagonal");
            this.matrix = CopyToDiagonalMatrix(matrix);
            
        }
        public override T this[int i, int j]
        {
            get
            {
                if (ExistingElement(i, j))
                {
                    if (i == j)
                        return matrix[i];
                    else
                        return default(T);
                }
                else
                    throw new ArgumentException();
            }
            set
            {
                if (i != j || !ExistingElement(i, j))
                    throw new ArgumentException();
                OnValueChange(new MatrixEventArgs<T>(i, j, value, matrix[i]));
                matrix[i] = value;
                
            }
        }
        private bool IsDiagonal(T[,] matrix)
        {
            Size = matrix.GetLength(0);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j && !Equals(matrix[i, j], default(T)))
                        return false;
                }
            }
            return true;
        }
        private T[] CopyToDiagonalMatrix(T[,] matrix)
        {
            Size = matrix.GetLength(0);
            T[] tempMatrix = new T[Size];
            for (int i = 0, j = 0; i < Size; i++, j++)
            {
                tempMatrix[i] = matrix[i, j];
            }
            return tempMatrix;
        }
    }
}
