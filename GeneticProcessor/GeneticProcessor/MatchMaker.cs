using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProcessor
{
    public class MatchMaker
    {
        public MatchMaker(Population population)
        {
            RouletteWheel wheel = new RouletteWheel(population);
            Matches = CreateMatches(population, wheel);
        }

        /// <summary>
        /// This is the roulette wheel selection algorithm function. It will return a list of matches that will be used for reproduction.
        /// Each chomosome will get a weigthed opportunity to be in a match based on it's fintess score.
        /// </summary>
        /// <param name="population"></param>
        /// <param name="selectionProbabilities"></param>
        /// <returns></returns>
        private IEnumerable<Match> CreateMatches(Population population, RouletteWheel wheel)
        {
            if (population.Count <= 1)
                return new Match[] { };

            List<Chromosome> mattingPool = new List<Chromosome>();
            Dictionary<Tuple<int, int>, Match> result = new Dictionary<Tuple<int, int>, Match>();

            while (mattingPool.Count < population.Count)
                mattingPool.Add(population.GetMate(wheel.GetFitnessValue()));


            //Use the % to find what fitness number to use. The random number should be between two % values, always use the fitness from the larger value.
            //The look for the chomosome that has that fitness. If more than one does randomly select one.

            //There is a bug in this algorithm that can make an asexual mating. Need to fix this somethat we can spin the roulettel wheel again to try and select a different mate, or select another result from the existing results.
            int matchesNeeded = population.Count / 2;
            Random randomNumber = new Random();

            while (result.Count < matchesNeeded)
            {
                Chromosome patternal = mattingPool[randomNumber.Next(mattingPool.Count)];
                Chromosome matternal = mattingPool[randomNumber.Next(mattingPool.Count)];

                if (patternal.Equals(matternal))
                    continue;

                Tuple<int, int> key;
                if (patternal.Fitness < matternal.Fitness)
                    key = new Tuple<int, int>(matternal.Fitness, patternal.Fitness);
                else
                    key = new Tuple<int, int>(patternal.Fitness, matternal.Fitness);

                if (result.ContainsKey(key))
                    continue;

                result.Add(key, new Match() { Patternal = patternal, Matternal = matternal });
            }

            return result;
        }

        public IEnumerable<Match> Matches { get; private set; }
    }
}
