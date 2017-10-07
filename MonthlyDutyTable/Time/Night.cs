using System;
using System.Runtime.CompilerServices;

namespace MonthlyDutyTable.Time
{
    public sealed class Night : TimePeriod
    {
        public DateTime DateTime { get; }
        public override DateTime StartingTime => DateTime;
        public override DateTime EndingTime => DateTime;
        public override int Length => 1;

        public Night(DateTime dateTime, int guardingAmount) : base(guardingAmount)
        {
            DateTime = dateTime;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int DistanceTo(Night night) => DateTime.Subtract(night.DateTime).Duration().Days;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Distance(Night n1, Night n2) => n1.DistanceTo(n2);

        public override string ToString()
        {
            return DateTime.ToString("dd/MM/yyyy");
        }
    }
}
