using System;
using System.Diagnostics;

namespace MonthlyDutyTable.GeneticAlgorithm
{
    public sealed class GeneticSettings
    {
        public int PopSize { get; }
        public double ElitismRate { get; }
        public double NewGenesRate { get; }
        public double MutationRate { get; }
        public TimeSpan RunningTime { get; }
        public int NewGenesAmount { get; }
        public int ElitismAmount { get; }

        public GeneticSettings(int popSize, double elitismRate, double newGenesRate, double mutationRate, TimeSpan runningTime)
        {
            Debug.Assert(elitismRate >= 0);
            Debug.Assert(newGenesRate >= 0);
            Debug.Assert(elitismRate + newGenesRate < 1.0);
            Debug.Assert(mutationRate >= 0 && mutationRate < 0.99, "Mutation rate at most 0.99");
            PopSize = popSize;
            ElitismRate = elitismRate;
            NewGenesRate = newGenesRate;
            MutationRate = mutationRate;
            RunningTime = runningTime;
            NewGenesAmount = (int)(NewGenesRate * popSize);
            ElitismAmount = (int)(ElitismRate * popSize);
        }
    }
}
