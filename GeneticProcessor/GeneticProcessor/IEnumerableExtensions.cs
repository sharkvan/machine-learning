using GeneticProcessor.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            return new ForEachEnumerable<T>(list, action);
        }

        public static void Run<T>(this IEnumerable<T> list)
        {
            foreach (T item in list) ;
        }
    }
}
