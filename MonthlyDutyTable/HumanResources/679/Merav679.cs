using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Merav679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Merav 679"),
                        new HebrewName("מירב 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath2.Duty(false, Role.Mashlat)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0),
                        Constraint.CantMonday,
                        Constraint.CantWednesday,
                        Constraint.CantDay(29));
    }
}
