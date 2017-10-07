using System.Collections.Generic;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public sealed class CantDaysConstraint : Constraint
    {
        public HashSet<int> Days { get; }

        public CantDaysConstraint(IEnumerable<int> days)
        {
            Days = new HashSet<int>(days);
        }

        public override bool IsSatasfied(Duty<Night> duty)
        {
            return !Days.Contains(duty.DaysTime.DateTime.Day);
        }
    }
}
