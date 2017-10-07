using System;
using MonthlyDutyTable.Utils;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MonthlyDutyTable.GeneticAlgorithm
{
    public sealed class Genetic<ProblemInstance, SolutionInstance> : IComparer<SolutionInstance>
        where SolutionInstance : IGeneticSolution<SolutionInstance>
    {
        public Func<ProblemInstance, Random, SolutionInstance> SolutionsRandomGenerator { get; }

        public Genetic(Func<ProblemInstance, Random, SolutionInstance> solutionsRandomGenerator)
        {
            SolutionsRandomGenerator = solutionsRandomGenerator;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(SolutionInstance s1, SolutionInstance s2) => s1.NegativePrice.CompareTo(s2.NegativePrice);

        public SolutionInstance Run(ProblemInstance problemInstance, GeneticSettings settings, Action<string> reportProgress, Random rnd)
        {
            var endingTime = DateTime.Now + settings.RunningTime;

            var population = new SolutionInstance[settings.PopSize];
            var newPopulation = population.Copy();

            for (int i = 0; i < population.Length; i++)
                population[i] = SolutionsRandomGenerator(problemInstance, rnd);
            Array.Sort(population, this);
            
            int lastNegativePrice = int.MaxValue;

            while (DateTime.Now < endingTime && population[0].NegativePrice > 0)
            {
                int newNegativePrice = population[0].NegativePrice;
                if (newNegativePrice < lastNegativePrice)
                {
                    reportProgress(population[0].NegativePrice.ToString());
                    lastNegativePrice = newNegativePrice;
                }

                int index = 0;
                for (int i = 0; i < settings.ElitismAmount; i++)
                    newPopulation[index] = population[index++];
                for (int i = 0; i < settings.NewGenesAmount; i++)
                    newPopulation[index++] = SolutionsRandomGenerator(problemInstance, rnd);
                while (index < newPopulation.Length)
                {
                    var mom = population.ChooseRandomly(rnd);
                    var dad = population.ChooseRandomly(rnd);
                    newPopulation[index++] = mom.MateMutate(dad, settings.MutationRate, rnd);
                }

                var temp = population;
                population = newPopulation;
                newPopulation = temp;

                Array.Sort(population, this);
            }
            reportProgress(population[0].NegativePriceExplanation());
            return population[0];
        }
    }
}
