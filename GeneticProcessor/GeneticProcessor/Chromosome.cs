using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    [DebuggerDisplay("{Fitness}")]
    public class Chromosome : IChromosome
    {
        private int _fitness;
        private NumericGene[] _genes;

        public Chromosome(IEnumerable<NumericGene> genes)
        {
            _genes = genes.ToArray();
            _fitness = _genes.Aggregate((a, b)=> a + b).Value;
        }

        public int Fitness { get { return _fitness; } }


        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IChromosome Crossover(IChromosome chromosome, int crossoverPoint)
        {
            throw new NotImplementedException();
        }
    }
}
