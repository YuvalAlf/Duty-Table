using System;
using System.Linq;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Utils;
using static System.DayOfWeek;

namespace MonthlyDutyTable.Program.DutyTableProblemInstance
{
    public static class CurrentNights
    {
        public static readonly Night Night1 = new Night(new DateTime(2017, 10, 1), 2);
        public static readonly Night Night2 = new Night(new DateTime(2017, 10, 2), 2);
        public static readonly Night Night3 = new Night(new DateTime(2017, 10, 3), 3);

        public static readonly Night Night8 = new Night(new DateTime(2017, 10, 8), 2);
        public static readonly Night Night9 = new Night(new DateTime(2017, 10, 9), 3);
        public static readonly Night Night10 = new Night(new DateTime(2017, 10, 10), 3);

        public static readonly Night Night15 = new Night(new DateTime(2017, 10, 15), 2);
        public static readonly Night Night16 = new Night(new DateTime(2017, 10, 16), 2);
        public static readonly Night Night17 = new Night(new DateTime(2017, 10, 17), 3);
        public static readonly Night Night18 = new Night(new DateTime(2017, 10, 18), 3);

        public static readonly Night Night22 = new Night(new DateTime(2017, 10, 22), 2);
        public static readonly Night Night23 = new Night(new DateTime(2017, 10, 23), 2);
        public static readonly Night Night24 = new Night(new DateTime(2017, 10, 24), 3);
        public static readonly Night Night25 = new Night(new DateTime(2017, 10, 25), 3);

        public static readonly Night Night29 = new Night(new DateTime(2017, 10, 29), 2);
        public static readonly Night Night30 = new Night(new DateTime(2017, 10, 30), 2);
        public static readonly Night Night31 = new Night(new DateTime(2017, 10, 31), 3);
        public static readonly Night Night1_11 = new Night(new DateTime(2017, 11, 1), 3);

        private static readonly Lazy<Night[]> allNights = new Lazy<Night[]>(() => typeof(CurrentNights).AllStaticFields<Night>().ToArray());
        public static Night[] AllNights => allNights.Value;
    }
}
