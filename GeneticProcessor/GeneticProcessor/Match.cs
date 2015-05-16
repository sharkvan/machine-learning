using GeneticProcessor.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using GeneticProcessor.Linq;
using System;

namespace GeneticProcessor
{
    [DebuggerDisplay("{Patternal.Fitness},{Matternal.Fitness}")]
    public class Match
    {
        static Random randomNumber = new Random();

        public Match(IChromosome patternal, IChromosome matternal)
        {
            Patternal = patternal;
            Matternal = matternal;

            int crossoverPoint = randomNumber.Next(Patternal.Length - 1);

            Offspring = new[]{
                Patternal.Crossover(Matternal, crossoverPoint),
                Matternal.Crossover(Patternal, crossoverPoint)};
        }

        public IChromosome Patternal { get; private set; }

        public IChromosome Matternal { get; private set; }

        public IEnumerable<IChromosome> Offspring { get; private set; }
    }
}
