using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticProcessor;
using System.Linq;

namespace Tests.MatchMakerTests
{
    [TestClass]
    public class WhenThePopulationIsEmpty
    {
        MatchMaker target = Senarios.EmptyPopulation;

        [TestMethod]
        public void ThenThereShouldBeNoMatches()
        {
            Assert.AreEqual(0, target.Matches.Count());
        }

        //[TestMethod]
        //public void ThenThereShouldBeNoFitnessProbabilities()
        //{
        //    Assert.AreEqual(0, target.SelectionProbabilities.Count);
        //}
    }
}
