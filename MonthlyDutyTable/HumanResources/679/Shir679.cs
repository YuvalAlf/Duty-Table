using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Shir679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shir 679"),
                        new HebrewName("שיר 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(1),
                        new NotGuardingAmount(3),
                        Constraint.CantDay(24),
                        Constraint.CantDay(29));
    }
}
