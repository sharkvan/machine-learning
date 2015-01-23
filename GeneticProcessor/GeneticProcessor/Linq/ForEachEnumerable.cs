using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor.Linq
{
    internal class ForEachEnumerable<T> : IEnumerable<T>
    {
        readonly IEnumerable<T> _enumerable;
        readonly Action<T> _action;

        public ForEachEnumerable(IEnumerable<T> enumerable, Action<T> action)
        {
            _enumerable = enumerable;
            _action = action;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ForEachEnumerator<T>(_enumerable.GetEnumerator(), _action);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
