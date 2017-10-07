using System;

namespace MonthlyDutyTable.GeneticAlgorithm
{
    public interface IGeneticSolution<Solution>
    {
        int NegativePrice { get; }
        Solution MateMutate(Solution otherSolution, double mutationRatem, Random rnd);
        string NegativePriceExplanation();
        string Validate();
    }
}
