using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources._474
{
    public static class Ofek474
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Ofek 474"),
                        new HebrewName("אופק 474"),
                        Unit.Unit474,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(2),
                        Constraint.CantRange(9, 12));
    }
}
