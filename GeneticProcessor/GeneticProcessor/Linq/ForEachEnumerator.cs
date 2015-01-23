using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor.Linq
{
    internal class ForEachEnumerator<T> : IEnumerator<T>
    {
        IEnumerator<T> _enumerator;
        Action<T> _action;

        public ForEachEnumerator(IEnumerator<T> enumerator, Action<T> action)
        {
            _enumerator = enumerator;
            _action = action;
        }

        public T Current
        {
            get
            {
                return _enumerator.Current;
            }
        }

        public void Dispose()
        {
            _action = null;

            if (_enumerator != null)
                _enumerator.Dispose();

            _enumerator = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (_enumerator.MoveNext())
            {
                _action(_enumerator.Current);
                return true;
            }

            return false;
        }

        public void Reset()
        {
            if (_enumerator != null)
                _enumerator.Reset();
        }
    }
}
