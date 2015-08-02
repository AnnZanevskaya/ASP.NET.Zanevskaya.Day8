using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class MatrixEventArgs<T> : EventArgs
    {
        public int I { get; private set; }
        public int J { get; private set; }
        public T NewV { get; private set; }
        public T OldV { get; private set; }

        public MatrixEventArgs(int i, int j, T newV, T oldV)
        {
            I = i;
            J = j;
            NewV = newV;
            OldV = oldV;
        }
    }
}
