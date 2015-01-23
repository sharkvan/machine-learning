using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationIsEmpty
    {
        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(0, 
                Scenarios.EmptyPopulation.MatchMaker.Matches.Count());
        }

        [TestMethod]
        public void ThenThereShouldBeNoFitnessProbabilities()
        {
            Assert.AreEqual(0, 
                Scenarios.EmptyPopulation.RouletteWheel.SelectionProbabilities.Count);
        }

        [TestMethod]
        public void ThePopulationCountShouldBeZero()
        {
            Assert.AreEqual(0,
                Scenarios.EmptyPopulation.Population.Count);
        }

        [TestMethod]
        public void ThePopulationFitnessShouldBeZero()
        {
            Assert.AreEqual(0,
                Scenarios.EmptyPopulation.Population.Fitness);
        }

        [TestMethod]
        public void TheRouletteWheelShouldNotReturnAFitness()
        {
            Assert.AreEqual(0,
                Scenarios.EmptyPopulation.RouletteWheel.GetFitnessValue());
        }
    }
}
