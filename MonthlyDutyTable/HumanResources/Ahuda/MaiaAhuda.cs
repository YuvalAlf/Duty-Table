using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class MaiaAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Maia Ahuda"),
                        new HebrewName("מאיה אחודה"),
                        Unit.Ahuda,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath2.Duty(true, Role.ToranShomer1)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0));
    }
}
