using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class SquareMatrix<T>: AbstractMatrix<T>
    {
        protected T[] matrix;
        protected SquareMatrix() {}
        public SquareMatrix(int size)
        {
            if (size < 0) throw new ArgumentException("Size is invalid");
            matrix = new T[size * size];
            Size = size; 
        }
        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException("Matrix is null");
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("Matrix should be square");
            this.matrix = CopyToSquareMatrix(matrix);
        }
        public override T this[int i, int j]
        {
            get
            {
                if(ExistingElement(i,j)) 
                    return matrix[(i * Size) + j];
                else 
                    throw new ArgumentException("Element doesn't exist");
            }
            set
            {
                if (!ExistingElement(i, j))
                    throw new ArgumentException("Element doesn't exist");
                OnValueChange(new MatrixEventArgs<T>(i, j, value, matrix[(i * Size) + j])); 
                matrix[(i * Size) + j] = value;
                                  
            }
        }
        protected bool ExistingElement(int i, int j)
        {
            return i >= 0 && j >= 0 && i < Size && j < Size;
        }
        private T[] CopyToSquareMatrix(T[,] matrix)
        {
            Size = matrix.GetLength(0);
            T[] tempMatrix = new T[Size * Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    tempMatrix[(i * Size) + j] = matrix[i, j];
                }
            }
            return tempMatrix;
        }
    }
}
