using System;

namespace MonthlyDutyTable.Time
{
    public sealed class Shabath : TimePeriod
    {
        public override DateTime StartingTime { get; }
        public override DateTime EndingTime { get; }
        public override int Length { get; }

        public Shabath(DateTime startingTime, DateTime endingTime, int guardingAmount) : base(guardingAmount)
        {
            StartingTime = startingTime;
            EndingTime = endingTime;
            Length = EndingTime.Subtract(StartingTime).Days + 1;
        }
        public override string ToString()
        {
            return StartingTime.ToString("dd/MM/yyyy") + " - " + EndingTime.ToString("dd/MM/yyyy");
        }
    }
}
