using System;
using System.Collections.Generic;

namespace GeneticProcessor
{
    public interface IPopulation : IEnumerable<IChromosome>
    {
        int Count { get; }
        int Fitness { get; }
        IChromosome GetMate(int fitness);
    }
}
