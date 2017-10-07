using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Karin9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Karin 9"),
                        new HebrewName("קארין 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath1.Duty(false, Role.Magam)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantMashlat);
    }
}
