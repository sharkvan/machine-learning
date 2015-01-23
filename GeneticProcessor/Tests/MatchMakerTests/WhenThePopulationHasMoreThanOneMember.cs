using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationHasMoreThanOneMember
    {
        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(2,
                Scenarios.FullPopulation.MatchMaker.Matches.Count());
        }

        [TestMethod]
        public void PropbabilityCountShouldBeSameAsPopulationCount()
        {
            Assert.AreEqual(
                Scenarios.FullPopulation.Population.Count, 
                Scenarios.FullPopulation.RouletteWheel.SelectionProbabilities.Count);
        }

        [TestMethod]
        public void SelectionProbabilityValuesShouldBeProportionalToFitnessValue()
        {
            Assert.AreEqual(0.144m, Scenarios.FullPopulation.RouletteWheel.SelectionProbabilities[169]);
            Assert.AreEqual(0.492m, Scenarios.FullPopulation.RouletteWheel.SelectionProbabilities[576]);
            Assert.AreEqual(0.055m, Scenarios.FullPopulation.RouletteWheel.SelectionProbabilities[64]);
            Assert.AreEqual(0.309m, Scenarios.FullPopulation.RouletteWheel.SelectionProbabilities[361]);
        }

        [TestMethod]
        public void ThePopulationFitnessShouldEqualTheMemberFitnessTotal()
        {
            Assert.AreEqual(
                1170, 
                Scenarios.FullPopulation.Population.Fitness);
        }

        [TestMethod]
        public void TheRouletteWheelShouldNotReturnAFitnessGreaterThanZero()
        {
            Assert.AreNotEqual(0,
                Scenarios.FullPopulation.RouletteWheel.GetFitnessValue());
        }
    }
}
