using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources.Mafog
{
    public static class MorazMafog
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Moraz Mafog"),
                        new HebrewName("מורז מפאוג"),
                        Unit.Mafog,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath3.Duty(true, Role.Magam)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantDays(25, 26));
    }
}
