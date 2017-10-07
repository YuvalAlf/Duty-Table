using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class NitsanAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Nitsan Ahuda"),
                        new HebrewName("ניצן אחודה"),
                        Unit.Ahuda,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath5.Duty(false, Role.Magam)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1));
    }
}
