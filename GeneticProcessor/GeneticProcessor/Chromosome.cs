using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    public class Chromosome
    {
        private int _fitness;

        public Chromosome(int fitness)
        {
            _fitness = fitness;
        }

        public int Fitness { get { return _fitness; } }
    }
}
