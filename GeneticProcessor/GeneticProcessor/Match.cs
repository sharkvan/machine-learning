using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GeneticProcessor
{
    [DebuggerDisplay("{Patternal.Fitness},{Matternal.Fitness}")]
    public class Match
    {
        public Chromosome Patternal { get; set; }
        public Chromosome Matternal { get; set; }
        public IEnumerable<Chromosome> Offspring { get; set; }
    }
}
