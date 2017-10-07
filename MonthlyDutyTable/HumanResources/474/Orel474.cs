using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._474
{
    public static class Orel474

    {
    public static readonly Soldier Soldier =
        new Soldier(new EnglishName("Orel 474"),
                    new HebrewName("אוראל 474"),
                    Unit.Unit474,
                    Guarding.CanGuard,
                    Test.DidntPass,
                    Duty.Nights(),
                    Duty.Shabathes(CurrentSabathes.Shabath3.Duty(true, Role.ToranShomer1)),
                    new GuardingAmount(2),
                    new NotGuardingAmount(0),
                    Constraint.CantRange(1, 9));
    }
}
