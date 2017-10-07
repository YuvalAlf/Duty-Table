using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.SoldiersConstraints;
using MonthlyDutyTable.Time;


namespace MonthlyDutyTable.HumanResources.Ahuda
{
    public static class SofiaAhuda
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Sofia Ahuda"),
                        new HebrewName("סופיה אחודה"),
                        Unit.Ahuda,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(CurrentNights.Night31.Duty(false, Role.InfoCenter)),
                        Duty.Shabathes(CurrentSabathes.Shabath4.Duty(false, Role.InfoCenter)),
                        new GuardingAmount(0),
                        new NotGuardingAmount(1),
                        Constraint.CantRange(1, 4));
    }
}
