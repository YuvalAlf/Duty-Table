using System;
using System.Runtime.CompilerServices;
using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.Time
{
    public abstract class TimePeriod : IComparable<TimePeriod>
    {
        public int GuardingAmount { get; }
        public abstract DateTime StartingTime { get; }
        public abstract DateTime EndingTime { get; }
        public virtual int Length => EndingTime.Subtract(StartingTime).Days + 1;

        protected TimePeriod(int guardingAmount)
        {
            GuardingAmount = guardingAmount;
        }


        public int DistanceTo(TimePeriod other)
        {
            if (this.StartingTime > other.EndingTime)
                return (this.StartingTime - other.EndingTime).Days;
            return (other.StartingTime - this.EndingTime).Days;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(TimePeriod other) => StartingTime.CompareTo(other.StartingTime);
        public override int GetHashCode()      => StartingTime.GetHashCode();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(TimePeriod other)   => StartingTime.Equals(other.StartingTime);
        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
                return Equals((TimePeriod)obj);
            return false;
        }

    }

    public static class TimePeriodUtils
    {
        public static Duty<Time> Duty<Time>(this Time @this, bool isGuarding, Role role)
            where Time:TimePeriod
        {
            return new Duty<Time>(isGuarding, @this, role);
        }
    }
}
