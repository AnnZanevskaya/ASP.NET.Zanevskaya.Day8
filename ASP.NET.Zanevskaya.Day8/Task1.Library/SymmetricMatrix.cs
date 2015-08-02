using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class SymmetricMatrix<T>: SquareMatrix<T>
    {
        public SymmetricMatrix(int size)
        {
            if (size < 0) throw new ArgumentException("Size is invalid");
            matrix = new T[(size + 1) * size / 2];
            Size = size;
        }
        public SymmetricMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException("Matrix is null");
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("Matrix should be square");
            if(!IsSymmetric(matrix))
               throw new ArgumentException("Matrix should be Symmetric");
            this.matrix = CopyToSymmetricMatrix(matrix);
        }
        public override T this[int i, int j]
        {
            get
            {
                if (ExistingElement(i, j))
                    return matrix[(i + 1) * i / 2 + j];
                else
                    throw new ArgumentException();
            }
            set
            {
                if (!ExistingElement(i, j))
                    throw new ArgumentException();
                OnValueChange(new MatrixEventArgs<T>(i, j, value, matrix[(i + 1) * i / 2 + j]));
                matrix[(i + 1) * i / 2 + j] = value;
            }
        }
        private bool IsSymmetric(T[,] matrix)
        {
            Size = matrix.GetLength(0);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                     if (!Equals(matrix[j, i], matrix[i, j]))
                        return false;
                }
            }
            return true;
        }
        private T[] CopyToSymmetricMatrix(T[,] matrix)
        {
            Size = matrix.GetLength(0);
            T[] tempMatrix = new T[(Size + 1) * Size / 2];
            for (int i = 0, k = 0; i < Size; i++)
            {
                for (int j = 0; j < Size - i; j++)
                {
                    tempMatrix[k] = matrix[i, j];
                    k++;
                }
            }
            return tempMatrix;
        }
    }
}
