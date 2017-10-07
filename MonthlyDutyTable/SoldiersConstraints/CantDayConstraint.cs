using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public sealed class CantDayConstraint : Constraint
    {
        public int DayNum { get; }

        public CantDayConstraint(int dayNum)
        {
            DayNum = dayNum;
        }

        public override bool IsSatasfied(Duty<Night> duty)
        {
            return duty.DaysTime.DateTime.Day != this.DayNum;
        }
    }
}
