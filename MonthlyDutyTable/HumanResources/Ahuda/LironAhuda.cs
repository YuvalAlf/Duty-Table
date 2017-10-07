using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class LironAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Liron Ahuda"),
                        new HebrewName("לירון אחודה"),
                        Unit.Ahuda,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath5.Duty(true, Role.ToranShomer2)),
                        new GuardingAmount(2),
                        new NotGuardingAmount(0),
                        Constraint.CantDay(27));
    }
}
