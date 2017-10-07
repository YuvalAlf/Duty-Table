using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._474
{
    public static class Yahel474
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Yahel Or 474"),
                        new HebrewName("יהל אור 474"),
                        Unit.Unit474,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(1),
                        new NotGuardingAmount(2));
    }
}
