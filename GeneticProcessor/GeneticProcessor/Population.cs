using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProcessor
{
    public class Population : IPopulation
    {
        List<IChromosome> _population;
        Random randomNumber = new Random();

        public Population(IEnumerable<IChromosome> population)
        {
            _population = new List<IChromosome>(population);
            Fitness = CalculatePopulationFitness(population);
        }

        public IChromosome GetMate(int fitness)
        {
            List<IChromosome> mates = _population.Where(mate => mate.Fitness.Equals(fitness)).ToList();

            if (mates.Count == 1)
                return mates[0];
            else
                return mates[randomNumber.Next(0, mates.Count-1)];
        }

        private static int CalculatePopulationFitness(IEnumerable<IChromosome> population)
        {
            int result = 0;

            foreach (IChromosome chromosome in population)
                result += chromosome.Fitness;

            return result;
        }

        public int Fitness { get; private set; }

        public int Count
        {
            get { return _population.Count; }
        }

        public IEnumerator<IChromosome> GetEnumerator()
        {
            return _population.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
