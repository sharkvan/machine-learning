using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    public class Population : IEnumerable<Chromosome>
    {
        List<Chromosome> _population;
        Random randomNumber = new Random();

        public Population(IEnumerable<Chromosome> population)
        {
            _population = new List<Chromosome>(population);
            Fitness = CalculatePopulationFitness(population);
        }

        public Chromosome GetMate(int fitness)
        {
            List<Chromosome> mates = _population.Where(mate => mate.Fitness.Equals(fitness)).ToList();

            if (mates.Count == 1)
                return mates[0];
            else
                return mates[randomNumber.Next(0, mates.Count-1)];
        }

        private static int CalculatePopulationFitness(IEnumerable<Chromosome> population)
        {
            int result = 0;

            foreach (Chromosome chromosome in population)
                result += chromosome.Fitness;

            return result;
        }

        public int Fitness { get; private set; }

        public int Count
        {
            get { return _population.Count; }
        }

        public IEnumerator<Chromosome> GetEnumerator()
        {
            return _population.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
