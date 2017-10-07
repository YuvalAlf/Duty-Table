using System;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public abstract class Constraint
    {
        public abstract bool IsSatasfied(Duty<Night> duty);

        public static Constraint CantDay(int dayNum) => new CantDayConstraint(dayNum);
        public static Constraint CantDays(params int[] dayNums) => new CantDaysConstraint(dayNums);
        public static Constraint CantRange(int startingDay, int endingDay) => new CantDayRangeConstraint(startingDay, endingDay);

        public static Constraint CantSunday => new CantDayOfWeekConstraint(DayOfWeek.Sunday);
        public static Constraint CantMonday => new CantDayOfWeekConstraint(DayOfWeek.Monday);
        public static Constraint CantTuesday => new CantDayOfWeekConstraint(DayOfWeek.Tuesday);
        public static Constraint CantWednesday => new CantDayOfWeekConstraint(DayOfWeek.Wednesday);

        public static Constraint CantInfoCenter => new CantRoleConstraint(Role.InfoCenter);
        public static Constraint CantMagam => new CantRoleConstraint(Role.Magam);
        public static Constraint CantMashlat => new CantRoleConstraint(Role.Mashlat);
    }
}
