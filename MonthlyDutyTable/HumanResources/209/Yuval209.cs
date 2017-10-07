using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._209
{
    public static class Yuval209
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Yuval 209"),
                        new HebrewName("יובל 209"),
                        Unit.Unit209,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(3),
                        new NotGuardingAmount(0),
                        Constraint.CantSunday,
                        Constraint.CantTuesday,
                        Constraint.CantDay(24));
    }
}
