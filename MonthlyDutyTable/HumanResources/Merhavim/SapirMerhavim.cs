using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources.Merhavim
{
    public static class SapirMerhavim
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Sapir Merhavim"),
                        new HebrewName("ספיר מרחבים"),
                        Unit.Merhavim,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(4),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(8, 12),
                        Constraint.CantDay(25));
    }
}
