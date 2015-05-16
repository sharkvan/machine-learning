using GeneticProcessor;

namespace Tests.MatchMakerTests.Scenarios
{
    static class EmptyPopulation
    {
        public static Chromosome[] Chromosomes = new Chromosome[] { };

        public static Population Population = new Population(
            Chromosomes);

        public static RouletteWheel RouletteWheel = new RouletteWheel(
            Population);

        public static MatchMaker MatchMaker = new MatchMaker(
            Population,
            RouletteWheel);
    }

    static class OneMemberPopulation
    {
        public static Chromosome[] Chromosomes = new Chromosome[]{
            new Chromosome(new NumericGene[]{new NumericGene(10)})};

        public static Population Population = new Population(
            Chromosomes);

        public static RouletteWheel RouletteWheel = new RouletteWheel(
            Population);

        public static MatchMaker MatchMaker = new MatchMaker(
            Population,
            RouletteWheel);
    }

    static class FullPopulation
    {
        public static Chromosome[] Chromosomes = new Chromosome[]{
                new Chromosome(new NumericGene[]{new NumericGene(169)}),
                new Chromosome(new NumericGene[]{new NumericGene(576)}),
                new Chromosome(new NumericGene[]{new NumericGene(64)}),
                new Chromosome(new NumericGene[]{new NumericGene(361)})};

        public static Population Population = new Population(
            Chromosomes);

        public static RouletteWheel RouletteWheel = new RouletteWheel(
            Population);

        public static MatchMaker MatchMaker = new MatchMaker(
            Population,
            RouletteWheel);
    }
}
