using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProcessor
{
    public class RouletteWheel : IRouletteWheel
    {
        Random randomNumber = new Random();
        int[] wheel = new int[1000];

        public RouletteWheel(IPopulation population)
        {
            SelectionProbabilities = CreateSelectionProbabilities(population);

            int index = 0;
            SelectionProbabilities
                .ForEach(i =>
                {
                    int slots = (int)(i.Value * 1000);
                    for (int j = 0; j < slots && index < wheel.Length; ++j, ++index)
                        wheel[index] = i.Key;
                }).Run();

            Suffle(wheel);
            Suffle(wheel);
            Suffle(wheel);
        }

        private static void Suffle(int[] wheel)
        {
            Random randomNumber = new Random();

            for (int i = wheel.Length - 1; i > 1; --i)
            {
                int j = randomNumber.Next(0, i);
                int item = wheel[j];
                wheel[j] = wheel[i];
                wheel[i] = item;
            }
        }

        /// <summary>
        /// Returns a fitness value randomly selected from the wheel.
        /// </summary>
        /// <returns></returns>
        public int GetFitnessValue()
        {
            int spinNumber = (int)(randomNumber.NextDouble() * 1000);
            int fitnessValue = wheel[spinNumber];

            return fitnessValue;
        }

        private static Dictionary<int, decimal> CreateSelectionProbabilities(IPopulation population)
        {
            Dictionary<int, decimal> result = new Dictionary<int, decimal>();

            foreach (IChromosome chromosome in population)
                result[chromosome.Fitness] = decimal.Round(((decimal)chromosome.Fitness / population.Fitness), 3);

            return result;
        }

        public IDictionary<int, decimal> SelectionProbabilities { get; private set; }
    }
}
