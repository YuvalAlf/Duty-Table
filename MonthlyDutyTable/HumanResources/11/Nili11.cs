using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Nili11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Nili 11"),
                        new HebrewName("נילי 11"),
                        Unit.Unit11,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath2.Duty(true, Role.ToranShomer2)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(1, 7),
                        Constraint.CantRange(19, 24));
    }
}
