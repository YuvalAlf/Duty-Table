using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._9
{
    public static class Maayan9
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Maayan 9"),
                        new HebrewName("מעיין 9"),
                        Unit.Unit9,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath1.Duty(true, Role.ToranShomer1)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
