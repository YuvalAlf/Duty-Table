using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class DekelAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Dekel Ahuda"),
                        new HebrewName("דקל אחודה"),
                        Unit.Ahuda,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(4),
                        new NotGuardingAmount(0));
    }
}
