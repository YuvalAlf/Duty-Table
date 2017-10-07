using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Calanit9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Calanit 9"),
                        new HebrewName("כלנית 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath4.Duty(true, Role.ToranShomer2)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0));
    }
}
