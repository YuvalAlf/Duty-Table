using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources.Mafog
{
    public static class ShirMafog
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shir Mafog"),
                        new HebrewName("שיר מפאוג"),
                        Unit.Mafog,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(3),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(3, 5),
                        Constraint.CantRange(18, 19),
                        Constraint.CantRange(1, 3));
    }
}
