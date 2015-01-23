using System.Collections.Generic;
using System.Diagnostics;

namespace GeneticProcessor
{
    [DebuggerDisplay("{Patternal.Fitness},{Matternal.Fitness}")]
    public class Match
    {
        public IChromosome Patternal { get; set; }
        public IChromosome Matternal { get; set; }
        public IEnumerable<IChromosome> Offspring { get; set; }
    }
}
