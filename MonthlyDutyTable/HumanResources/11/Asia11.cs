using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using Constraint = MonthlyDutyTable.SoldiersConstraints.Constraint;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Asia11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Asia 11"),
                        new HebrewName("אסיה 11"),
                        Unit.Unit11,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath3.Duty(false, Role.InfoCenter)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(2),
                        Constraint.CantMashlat,
                        Constraint.CantRange(22, 28));
    }
}
