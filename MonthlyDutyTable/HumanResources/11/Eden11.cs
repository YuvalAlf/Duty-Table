using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Eden11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Eden 11"),
                        new HebrewName("עדן 11"),
                        Unit.Unit11,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
