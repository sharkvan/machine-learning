using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationHasOneMember
    {
        MatchMaker target = Senarios.OneMemberPopulation;
        

        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(0, target.Matches.Count());
        }

        //[TestMethod]
        //public void ThenThereShouldBeOneFintessProbability()
        //{
        //    Assert.AreEqual(1, target.SelectionProbabilities.Count);
        //}

        //[TestMethod]
        //public void TheOneFintessProbabilityShouldBe100Percent()
        //{
        //    Assert.AreEqual(1, target.SelectionProbabilities[10]);
        //}

        //[TestMethod]
        //public void ThePopulationFitnessShouldEqualTheOneMember()
        //{
        //    Assert.AreEqual(10, target.Population.Fitness);
        //}
    }
}
