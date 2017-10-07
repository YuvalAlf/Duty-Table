using System;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public sealed class CantDayOfWeekConstraint : Constraint
    {
        public DayOfWeek DayOfWeek { get; }

        public CantDayOfWeekConstraint(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }

        public override bool IsSatasfied(Duty<Night> duty)
        {
            return duty.DaysTime.DateTime.DayOfWeek != this.DayOfWeek;
        }
    }
}
