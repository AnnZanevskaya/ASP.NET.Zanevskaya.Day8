using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Library;

namespace Task1
{
    public sealed class Listeners<T>
    {
        public Listeners()  {  }
        public Listeners(AbstractMatrix<T> matrix)
        {
            matrix.ValueChanged += OnValueChanged;
        }
        private void OnValueChanged(Object sender, MatrixEventArgs<T> eventArgs)
        {
            Console.WriteLine(" Element[{0},{1}] - {2} has been changed on {3}", eventArgs.I, eventArgs.J, eventArgs.OldV, eventArgs.NewV);
        }
        public void Unregister(AbstractMatrix<T> matrix)
        {
            matrix.ValueChanged -= OnValueChanged;
        }
        public void Register(AbstractMatrix<T> matrix)
        {
            matrix.ValueChanged += OnValueChanged;
        }
    }
}
