using System;
using System.Collections;
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

            List<Chromosome> mattingPool;
            Dictionary<Tuple<int, int>, Match> result = new Dictionary<Tuple<int, int>, Match>();
            //Dictionary<int, int> hits = new Dictionary<int, int>();

            //do
            //{
            //    mattingPool = new List<Chromosome>();
            //    while (mattingPool.Count < population.Count)
            //    {
            //        int fitness = wheel.GetFitnessValue();
            //        //int max = (int)Math.Round(population.Count * wheel.SelectionProbabilities[fitness], 0);

            //        //if (!hits.ContainsKey(fitness))
            //        //    hits.Add(fitness, 1);
            //        //else
            //        //    hits[fitness]++;

            //        //if (hits[fitness] <= max)
            //        mattingPool.Add(population.GetMate(fitness));
            //    }
            //    //This do,while loop makes ure that we have atleast more than one possible mate.
            //} while (mattingPool.Select(i => i.Fitness).Distinct().Count() <= 1);

            //Use the % to find what fitness number to use. The random number should be between two % values, always use the fitness from the larger value.
            //The look for the chomosome that has that fitness. If more than one does randomly select one.

            int matchesNeeded = population.Count / 2;
            Random randomNumber = new Random();

            while (result.Count < matchesNeeded)
            {
                Chromosome patternal = population.GetMate(wheel.GetFitnessValue());
                Chromosome matternal = population.GetMate(wheel.GetFitnessValue());

                //This makes sure that there is no asexual matting.
                if (patternal.Equals(matternal))
                    continue;

                Tuple<int, int> key = new Tuple<int, int>(patternal.Fitness, matternal.Fitness);

                if (result.ContainsKey(key))
                    continue;

                result.Add(key, new Match() { Patternal = patternal, Matternal = matternal });
            }

            return result.Values;
        }

        public IEnumerable<Match> Matches { get; private set; }
    }
}
