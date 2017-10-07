using System;
using System.Linq;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources;
using MonthlyDutyTable.GeneticAlgorithm;

using MonthlyDutyTable.Program.DutyTableSolution;

namespace MonthlyDutyTable.Program.DutyTableProblemInstance
{
    public sealed class CurrentMonth : Month
    {
        private CurrentMonth(Soldier[] soldiers, Night[] nights, Shabath[] shabathes)
            :base("October", soldiers, nights, shabathes) { }

        public static CurrentMonth Create()
        {
            var soldiers = Soldier.AllSoldiers().ToArray();
            var nights = CurrentNights.AllNights;
            var shabathes = CurrentSabathes.AllShabathes;
            return new CurrentMonth(soldiers, nights, shabathes);
        }

        public DutyTable GenDutyTable(GeneticSettings geneticSettings, DutyTableConstraints constraints, Action<string> reportProgress, Random rnd)
        {
            var geneticAlg = new Genetic<CurrentMonth, DutyTable>((aug, rand) => aug.GenRandomDutyTable(constraints, rand));
            return geneticAlg.Run(this, geneticSettings, reportProgress, rnd);
        }

        public DutyTable GenRandomDutyTable(DutyTableConstraints constraints, Random rnd)
        {
            return DutyTable.TryGenRandomly(Nights, Soldiers, constraints, rnd, 20);
        }

    }
}
