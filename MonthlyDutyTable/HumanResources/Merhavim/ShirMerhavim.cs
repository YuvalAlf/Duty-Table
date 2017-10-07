using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;

namespace MonthlyDutyTable.HumanResources.Merhavim
{
    public static class ShirMerhavim
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shir Merhavim"),
                        new HebrewName("שיר מרחבים"),
                        Unit.Merhavim,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(2),
                        new NotGuardingAmount(1));
    }
}
