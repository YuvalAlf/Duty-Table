using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Yuval9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Yuval 9"),
                        new HebrewName("יובל 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(2),
                        Constraint.CantMashlat,
                        Constraint.CantRange(15, 18),
                        Constraint.CantRange(7, 15));
    }
}
