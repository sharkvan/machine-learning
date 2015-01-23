using System;
namespace GeneticProcessor
{
    public interface IRouletteWheel
    {
        int GetFitnessValue();
        System.Collections.Generic.IDictionary<int, decimal> SelectionProbabilities { get; }
    }
}
