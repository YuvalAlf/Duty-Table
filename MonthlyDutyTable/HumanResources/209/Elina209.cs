using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.SoldiersConstraints;


namespace MonthlyDutyTable.HumanResources._209
{
    public static class Elina209
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Elina 209"),
                        new HebrewName("אלינה 209"),
                        Unit.Unit209,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(2),
                        new NotGuardingAmount(1),
                        Constraint.CantMonday);
    }
}
