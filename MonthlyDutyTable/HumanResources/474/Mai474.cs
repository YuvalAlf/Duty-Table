using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources._474
{
    public static class Mai474
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Mai 474"),
                        new HebrewName("מאי 474"),
                        Unit.Unit474,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath1.Duty(true, Role.ToranShomer2)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0));
    }
}
