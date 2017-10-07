using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class ShaniAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Shani Ahuda"),
                        new HebrewName("שני אחודה"),
                        Unit.Ahuda,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(4),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(19, 24));
    }
}
