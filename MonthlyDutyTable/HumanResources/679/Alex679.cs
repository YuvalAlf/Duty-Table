using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Alex679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Alex 679"),
                        new HebrewName("אלכס 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath4.Duty(true, Role.ToranShomer1)),
                        new GuardingAmount(2),
                        new NotGuardingAmount(0));
    }
}
