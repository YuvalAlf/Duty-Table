using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Hadas679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Hadas 679"),
                        new HebrewName("הדס 679"),
                        Unit.Unit679,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath1.Duty(false, Role.Mashlat)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0),
                        Constraint.CantMonday,
                        Constraint.CantDay(29));
    }
}
