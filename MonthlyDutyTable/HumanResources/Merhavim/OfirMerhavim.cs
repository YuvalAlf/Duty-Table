using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources.Merhavim
{
    public static class OffirMerhavim
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Offir Merhavim"),
                        new HebrewName("אופיר מרחבים"),
                        Unit.Merhavim,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath4.Duty(false, Role.Mashlat)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantMonday,
                        Constraint.CantDays(1, 2));
    }
}
