using System;
namespace GeneticProcessor
{
    public interface IChromosome
    {
        int Fitness { get; }

        int Length { get; set; }

        IChromosome Crossover(IChromosome chromosome, int crossoverPoint);
    }
}
