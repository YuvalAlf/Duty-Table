using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources.Mafog
{
    public static class SherMafog
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Sher Mafog"),
                        new HebrewName("שר מפאוג"),
                        Unit.Mafog,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath3.Duty(true, Role.ToranShomer2)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(4, 14),
                        Constraint.CantRange(17, 18),
                        Constraint.CantRange(27, 28));
    }
}
