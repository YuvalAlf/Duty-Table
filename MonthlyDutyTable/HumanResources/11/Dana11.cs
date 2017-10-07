using MonthlyDutyTable.HumanResources.SoldierProperties;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.Program.DutyTableProblemInstance;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.HumanResources._11
{
    public static class Dana11
    {
        public static readonly Soldier Soldier =
            new Soldier(new EnglishName("Dana 11"),
                        new HebrewName("דנה 11"),
                        Unit.Unit11,
                        Guarding.CantGuard,
                        Test.Passed,
                        Duty.Nights(),
                        Duty.Shabathes(),
                        new GuardingAmount(0),
                        new NotGuardingAmount(4));
    }
}
