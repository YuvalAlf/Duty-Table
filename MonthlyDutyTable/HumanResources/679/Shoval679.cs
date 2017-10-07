using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Shoval679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shoval 679"),
                        new HebrewName("שובל 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath5.Duty(true, Role.InfoCenter)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(1),
                        Constraint.CantRange(16, 20),
                        Constraint.CantRange(28, 29));
    }
}
