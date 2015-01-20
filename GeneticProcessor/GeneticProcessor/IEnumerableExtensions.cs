using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            using (IEnumerator<T> enumerator = list.GetEnumerator())
                while (enumerator.MoveNext())
                    action(enumerator.Current);
        }
    }
}
