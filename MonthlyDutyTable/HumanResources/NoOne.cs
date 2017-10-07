using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.HumanResources
{
    public static class NoOne
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("No one"),
                        new HebrewName("אף אחד"),
                        Unit.NoUnit,
                        Guarding.CanGuard,
                        Test.Passed,
                        Duty.Nights(CurrentNights.Night1.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night3.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night8.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night9.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night15.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night16.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night17.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night18.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night22.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night23.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night24.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night29.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night30.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night31.Duty(false, Role.ToranShomer2),
                                    CurrentNights.Night1_11.Duty(false, Role.ToranShomer2)),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(15));
    }
}
