using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationHasOneMember
    {
        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(0,
                Scenarios.OneMemberPopulation.MatchMaker.Matches.Count());
        }

        [TestMethod]
        public void ThenThereShouldBeOneFintessProbability()
        {
            Assert.AreEqual(1,
                Scenarios.OneMemberPopulation.RouletteWheel.SelectionProbabilities.Count);
        }

        [TestMethod]
        public void TheOneFintessProbabilityShouldBe100Percent()
        {
            Assert.AreEqual(1,
                Scenarios.OneMemberPopulation.RouletteWheel.SelectionProbabilities[10]);
        }

        [TestMethod]
        public void ThePopulationFitnessShouldEqualTheOneMember()
        {
            Assert.AreEqual(10,
                Scenarios.OneMemberPopulation.Population.Fitness);
        }

        [TestMethod]
        public void TheRouletteWheelShouldReturnTheOnlyFitness()
        {
            Assert.AreEqual(10,
                Scenarios.OneMemberPopulation.RouletteWheel.GetFitnessValue());
        }
    }
}
