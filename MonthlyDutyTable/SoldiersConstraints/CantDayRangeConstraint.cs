using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public sealed class CantDayRangeConstraint : Constraint
    {
        public int StartingDayNum { get; }
        public int EndingDayNum { get; }

        public CantDayRangeConstraint(int startingDayNum, int endingDayNum)
        {
            StartingDayNum = startingDayNum;
            EndingDayNum = endingDayNum;
        }

        public override bool IsSatasfied(Duty<Night> duty)
        {
            return duty.DaysTime.DateTime.Day < StartingDayNum || duty.DaysTime.DateTime.Day > EndingDayNum;
        }
    }
}
