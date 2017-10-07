using System.Text;
using System.Linq;
using System.Reflection;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Utils;
using MonthlyDutyTable.Roles;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableSolution;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources
{
    public sealed class Soldier
    {
        public string EnglishName { get; }
        public string HebrewName { get; }
        public Unit Unit { get; }

        public bool CanGuard { get; }
        public bool PassTest { get; }

        public Duty<Night>[] KnownNightsDoing { get; }
        public Duty<Shabath>[] KnownShabathes { get; }

        public int NightsGuardingAmount { get; }
        public int NightsNotGuardingAmount { get; }

        public Constraint[] Constraints { get; }

        public bool IsDone { get; }

        public Soldier(EnglishName englishName, HebrewName hebrewName, Unit unit, Guarding guarding, Test test, Duty<Night>[] knownNightsDoing, Duty<Shabath>[] knownShabathes, GuardingAmount guardingAmount, NotGuardingAmount notGuardingAmount, params Constraint[] constraints)
        {
            EnglishName = englishName.Name;
            HebrewName = hebrewName.Name;
            Unit = unit;
            CanGuard = guarding == Guarding.CanGuard;
            PassTest = test == Test.Passed;
            KnownNightsDoing = knownNightsDoing;
            KnownShabathes = knownShabathes;
            NightsGuardingAmount = guardingAmount.Amount;
            NightsNotGuardingAmount = notGuardingAmount.Amount;
            Constraints = constraints;
            IsDone = KnownNightsDoing.Length == NightsGuardingAmount + NightsNotGuardingAmount;
            if (IsDone)
                System.Console.WriteLine(englishName.Name + " is done");
            if (NightsGuardingAmount < KnownNightsDoing.Count(d => d.IsGuarding))
                System.Console.WriteLine(englishName.Name + " guarding abnormality");
            if (NightsNotGuardingAmount < KnownNightsDoing.Count(d => !d.IsGuarding))
                System.Console.WriteLine(englishName.Name + " not guarding abnormality");
        }

        public override string ToString()   => EnglishName;
        public override int GetHashCode()   => EnglishName.GetHashCode();
        public bool Equals(Soldier soldier) => this.EnglishName.Equals(soldier.EnglishName);
        public override bool Equals(object obj)
        {
            if (obj is Soldier)
                return this.Equals(obj as Soldier);
            return false;
        }

        public bool CanDo(Duty<Night> nightDuty, 
                          Dictionary<Soldier, List<Duty<Night>>> nightDuties, 
                          Dictionary<Night, Dictionary<Role, Soldier>> soldierDuties, 
                          DutyTableConstraints dutyTableConstraints)
        { 
            if (IsDone)
                return false;
          //  if (nightDuty.IsGurading && NightsGuardingAmount == 0)
          //      return false;
           // if (!nightDuty.IsGurading && NightsNotGuardingAmount == 0)
           //     return false;
            if (nightDuty.IsGuarding && !CanGuard)
                return false;
            if (PassTest && nightDuty.Role == Role.ToranShomer1)
                return false;
            if (PassTest && nightDuty.Role == Role.ToranShomer2)
                return false;
            if (nightDuty.Role != Role.ToranShomer1 && nightDuty.Role != Role.ToranShomer2 && !PassTest)
                return false;
            if (Constraints.Any(c => !c.IsSatasfied(nightDuty)))
                return false;
            if (nightDuties[this].Any(n => n.DaysTime.DistanceTo(nightDuty.DaysTime) <= dutyTableConstraints.MinRangeBetweenNights))
                return false;
            if (KnownShabathes.Any(l => l.DaysTime.DistanceTo(nightDuty.DaysTime) <= dutyTableConstraints.MinRangeShabath))
                return false;
            if (soldierDuties[nightDuty.DaysTime].Values.Count(s => s.Unit == this.Unit) >= dutyTableConstraints.MaxSoldiersOfUnit[this.Unit])
                return false;
            if (dutyTableConstraints.UnitConstraints[Unit].Any(c => !c.IsSatasfied(nightDuty)))
                return false;
            return true;
        }
        
        public static IEnumerable<Soldier> AllSoldiers()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
                if (type.IsAbstract && type.IsSealed)
                    foreach (var soldier in type.AllStaticFields<Soldier>())
                        yield return soldier;
        }

        public static string AsCsvData(Soldier[] soldiers)
        {
            var csvLines = new StringBuilder();
            csvLines.AppendLine("חטיבה,שם,פטור שמירות?,עבר מבחן?,שבת שמירות,שבת בלי שמירות,לילות שמירה,לילות בלי שמירה");
            foreach (var soldier in soldiers)
                csvLines.Append(soldier.Unit.AsString()).Append(',')
                        .Append(soldier.HebrewName).Append(',')
                        .Append(!soldier.CanGuard).Append(',')
                        .Append(soldier.PassTest).Append(',')
                        .Append(soldier.KnownShabathes.Count(l => l.IsGuarding)).Append(',')
                        .Append(soldier.KnownShabathes.Count(l => !l.IsGuarding)).Append(',')
                        .Append(soldier.NightsGuardingAmount).Append(',')
                        .Append(soldier.NightsNotGuardingAmount).AppendLine();
            return csvLines.ToString();
        }
    }
}
