using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public abstract class AbstractMatrix<T>
    {
        public int Size { get; protected set; }
        public event EventHandler<MatrixEventArgs<T>> ValueChanged = delegate { };
        abstract public T this[int i, int j] { get; set; }
        protected virtual void OnValueChange(MatrixEventArgs<T> e)
        {
            ValueChanged(this, e);
        }
    }
}
