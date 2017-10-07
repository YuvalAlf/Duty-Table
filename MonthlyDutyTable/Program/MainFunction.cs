using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MonthlyDutyTable.Utils;
using static System.Environment;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources;
using MonthlyDutyTable.GeneticAlgorithm;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Program.DutyTableSolution;


using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.Program
{
    public static class MainFunction
    {
        static void Main(string[] args)
        {
            Assembly.GetExecutingAssembly().InitializeTypes();
            var rnd = new Random();

            var constraints = new DutyTableConstraints(minRangeBetweenNights: 2,
                                                       minRangeShabath: 4,
                                                       maxSoldiersOfUnit: new Dictionary<Unit, int>
                                                       {
                                                           {Unit.Unit9, 2},
                                                           {Unit.Unit11, 3},
                                                           {Unit.Unit209, 2},
                                                           {Unit.Unit474, 2},
                                                           {Unit.Unit679, 3},
                                                           {Unit.Mafog, 2},
                                                           {Unit.Merhavim, 2},
                                                           {Unit.Ahuda, 1},
                                                           {Unit.NoUnit, 100}
                                                       },
                                                       unitConstraints: new Dictionary<Unit, Constraint[]>
                                                       {
                                                           {Unit.Unit9, new Constraint[]{}},
                                                           {Unit.Unit11, new Constraint[]{ }},
                                                           {Unit.Unit209, new Constraint[]{ }},
                                                           {Unit.Unit474, new Constraint[]{ }},
                                                           {Unit.Unit679, new Constraint[]{ Constraint.CantDays(18, 19)}},
                                                           {Unit.Mafog, new Constraint[]{ }},
                                                           {Unit.Merhavim, new Constraint[]{ }},
                                                           {Unit.Ahuda, new Constraint[]{ }},
                                                           {Unit.NoUnit, new Constraint[]{ }}
                                                       });
            

            var reportProgress = new Action<string>(Console.WriteLine);
            var geneticSettings = new GeneticSettings(popSize:      50,
                                                      elitismRate:  0.3, 
                                                      newGenesRate: 0.1, 
                                                      mutationRate: 0.6, 
                                                      runningTime:  TimeSpan.FromSeconds(3));

            var month = CurrentMonth.Create();
            var desktopPath = GetFolderPath(SpecialFolder.Desktop);
            var dutyTablePath = Path.Combine(desktopPath, month.Name + " Duty Table.csv");
            var soldiersDataPath = Path.Combine(desktopPath, month.Name + " Soldiers Data.csv");

            reportProgress(month.ValidateSettings());
            reportProgress("Can guard: " + month.Soldiers.Count(s => s.CanGuard));
            reportProgress("Passed test: " + month.Soldiers.Count(s => s.PassTest));
            reportProgress("# of soldiers: " + month.Soldiers.Count());
            Soldier.AsCsvData(month.Soldiers).WriteToFile(soldiersDataPath);

            DutyTable dutyTable = month.GenDutyTable(geneticSettings, constraints, reportProgress, rnd);
            //dutyTable.Print(reportProgress);
            month.AsCsvData(dutyTable).WriteToFile(dutyTablePath);
            Console.ReadKey(false);
        }
    }
}
