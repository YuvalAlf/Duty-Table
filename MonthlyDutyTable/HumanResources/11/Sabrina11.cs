using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Saberina11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Sabrina 11"),
                        new HebrewName("סברינה 11"),
                        Unit.Unit11,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath2.Duty(false, Role.Magam)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0),
                        Constraint.CantDays(17, 19, 24));
    }
}
