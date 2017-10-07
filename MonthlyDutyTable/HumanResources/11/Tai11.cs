using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Tai11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Tai 11"),
                        new HebrewName("טאי 11"),
                        Unit.Unit11,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath1.Duty(true, Role.InfoCenter)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
