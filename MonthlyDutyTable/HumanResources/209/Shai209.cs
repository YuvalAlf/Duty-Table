using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources._209
{
    public static class Shai209
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shai 209"),
                        new HebrewName("שי 209"),
                        Unit.Unit209,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(3),
                        new NotGuardingAmount(1),
                        Constraint.CantRange(19, 21));
    }
}
