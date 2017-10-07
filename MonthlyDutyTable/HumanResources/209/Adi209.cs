using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._209
{
    public static class Adi209
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Adi 209"),
                        new HebrewName("עדי 209"),
                        Unit.Unit209,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath4.Duty(false, Role.Magam)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantMonday,
                        Constraint.CantTuesday,
                        Constraint.CantWednesday);
    }
}
