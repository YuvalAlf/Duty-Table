using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Shaked9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shaked 9"),
                        new HebrewName("שקד 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
