using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Bar9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Bar 9"),
                        new HebrewName("בר 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath2.Duty(false, Role.InfoCenter)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0));
    }
}
