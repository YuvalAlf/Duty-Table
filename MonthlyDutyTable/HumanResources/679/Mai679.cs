using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Mai679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Mai 679"),
                        new HebrewName("מאי 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0),
                        Constraint.CantDay(22),
                        Constraint.CantRange(24, 29));
    }
}
