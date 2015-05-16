using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    public class NumericGene : IGene
    {
        readonly int _value;

        public NumericGene(int value)
        {
            _value = value;
        }

        public int Value { get { return _value; } }

        public static NumericGene operator +(NumericGene a, NumericGene b)
        {
            return new NumericGene(a.Value + b.Value);
        }
    }
}
