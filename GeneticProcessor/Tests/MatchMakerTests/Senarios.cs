using GeneticProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.MatchMakerTests
{
    static class Senarios
    {
        public static MatchMaker EmptyPopulation = new MatchMaker(
            new Population(
             new Chromosome[] { }
            ));

        public static MatchMaker OneMemberPopulation = new MatchMaker(
            new Population(
             new Chromosome[] { new Chromosome(10) }
            ));

        public static MatchMaker FullPopulation = new MatchMaker(
            new Population(
             new Chromosome[] { 
                new Chromosome(169),
                new Chromosome(576),
                new Chromosome(64),
                new Chromosome(361)}
            ));
    }
}
