using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    public class RouletteWheel
    {
        Random randomNumber = new Random();
        int[] wheel = new int[1000];

        public RouletteWheel(Population population)
        {
            SelectionProbabilities = CreateSelectionProbabilities(population);

            int index = 0;
            SelectionProbabilities
                .ForEach(i =>
                {
                    int slots = (int)(i.Value * 1000);
                    for (int j = 0; j < slots && index < wheel.Length; ++j, ++index)
                        wheel[index] = i.Key;
                });
        }

        /// <summary>
        /// Returns a fitness value randomly selected from the wheel.
        /// </summary>
        /// <returns></returns>
        public int GetFitnessValue()
        {
            int spinNumber = (int)(randomNumber.NextDouble()*1000);
            int fitnessValue = wheel[spinNumber];
            return fitnessValue;

            //Chromosome patternal;
            //IEnumerable<Chromosome> mates = population.Where(mate => mate.Fitness.Equals(fitnessValue));

            //if (mates.Count() == 1)
            //    patternal = mates.First();
            //else
            //{
            //    patternal = mates.ElementAt(randomNumber.Next(0, mates.Count()));
            //}

        }

        private static Dictionary<int, decimal> CreateSelectionProbabilities(Population population)
        {
            Dictionary<int, decimal> result = new Dictionary<int, decimal>();

            foreach (Chromosome chromosome in population)
                result[chromosome.Fitness] = decimal.Round(((decimal)chromosome.Fitness / population.Fitness), 3);

            return result;
        }

        public IDictionary<int, decimal> SelectionProbabilities { get; private set; }
    }
}
