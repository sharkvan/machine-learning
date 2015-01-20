using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationHasMoreThanOneMember
    {
        MatchMaker target = Senarios.FullPopulation;

        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(2
                , target.Matches.Count());
        }

        //[TestMethod]
        //public void CheckFitnessProbabilityCount()
        //{
        //    Assert.AreEqual(2, target.SelectionProbabilities.Count);
        //}

        //[TestMethod]
        //public void CheckFitnessProbabilityValues()
        //{
        //    Assert.AreEqual(0.144m, target.SelectionProbabilities[169]);
        //    Assert.AreEqual(0.492m, target.SelectionProbabilities[576]);
        //    Assert.AreEqual(0.055m, target.SelectionProbabilities[64]);
        //    Assert.AreEqual(0.309m, target.SelectionProbabilities[361]);
        //}

        //[TestMethod]
        //public void ThePopulationFitnessShouldEqualTheMemberFitnessTotal()
        //{
        //    Assert.AreEqual(1170, target.Population.Fitness);
        //}
    }
}
