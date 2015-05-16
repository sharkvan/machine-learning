using System;
using System.Collections.Generic;

namespace GeneticProcessor
{
    public class MatchMaker
    {
        public MatchMaker(IPopulation population, IRouletteWheel wheel)
        {
            Matches = CreateMatches(population, wheel);
        }

        /// <summary>
        /// This is the roulette wheel selection algorithm function. It will return a list of matches that will be used for reproduction.
        /// Each chomosome will get a weigthed opportunity to be in a match based on it's fintess score.
        /// </summary>
        /// <param name="population"></param>
        /// <param name="selectionProbabilities"></param>
        /// <returns></returns>
        private IEnumerable<Match> CreateMatches(IPopulation population, IRouletteWheel wheel)
        {
            if (population.Count <= 1)
                return new Match[] { };

            Dictionary<Tuple<int, int>, Match> result = new Dictionary<Tuple<int, int>, Match>();

            int matchesNeeded = population.Count / 2;
            Random randomNumber = new Random();

            while (result.Count < matchesNeeded)
            {
                IChromosome patternal = population.GetMate(wheel.GetFitnessValue());
                IChromosome matternal = population.GetMate(wheel.GetFitnessValue());

                //This makes sure that there is no asexual matting.
                if (patternal.Equals(matternal))
                    continue;

                Tuple<int, int> key = new Tuple<int, int>(patternal.Fitness, matternal.Fitness);

                if (result.ContainsKey(key))
                    continue;

                result.Add(key, new Match(patternal, matternal));
            }

            return result.Values;
        }

        public IEnumerable<Match> Matches { get; private set; }
    }
}
