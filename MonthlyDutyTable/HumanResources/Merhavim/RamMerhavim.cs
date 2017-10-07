using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources.Merhavim
{
    public static class RamMerhavim
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Ram Merhavim"),
                        new HebrewName("רם מרחבים"),
                        Unit.Merhavim,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath5.Duty(false, Role.Mashlat)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
