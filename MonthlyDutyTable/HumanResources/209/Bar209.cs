using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._209
{
    public static class Bar209
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Bar 209"),
                        new HebrewName("בר 209"),
                        Unit.Unit209,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath3.Duty(false, Role.Mashlat)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantDays(14, 15, 25, 26, 4));
    }
}
