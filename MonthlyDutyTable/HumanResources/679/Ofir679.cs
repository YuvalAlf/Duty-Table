using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.HumanResources._679
{
    public static class Ofir679
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Ofir 679"),
                        new HebrewName("אופיר 679"),
                        Unit.Unit679,
                        Guarding.CanGuard,
                        Test.DidntPass,
                        Duty.Nights(),
                        Duty.Shabathes(CurrentSabathes.Shabath5.Duty(true, Role.ToranShomer1)),
                        new GuardingAmount(1),
                        new NotGuardingAmount(0),
                        Constraint.CantRange(1, 15),
                        Constraint.CantDays(4, 18, 28));
    }
}
