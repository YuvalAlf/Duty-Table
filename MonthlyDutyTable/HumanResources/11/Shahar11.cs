using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Shahar11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shahar 11"),
                        new HebrewName("שחר 11"),
                        Unit.Unit11,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(3),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(19, 26),
                        Constraint.CantDay(15),
                        Constraint.CantDay(29));
    }
}
