using System;
using System.Linq;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Utils;

namespace MonthlyDutyTable.Program.DutyTableProblemInstance
{
    public static class CurrentSabathes
    {
        public static readonly Shabath Shabath1 = new Shabath(new DateTime(2017, 10, 4),  new DateTime(2017, 10, 7), 3);
        public static readonly Shabath Shabath2 = new Shabath(new DateTime(2017, 10, 11), new DateTime(2017, 10, 14), 2);
        public static readonly Shabath Shabath3 = new Shabath(new DateTime(2017, 10, 19), new DateTime(2017, 10, 21), 3);
        public static readonly Shabath Shabath4 = new Shabath(new DateTime(2017, 10, 26), new DateTime(2017, 10, 28), 2);
        public static readonly Shabath Shabath5 = new Shabath(new DateTime(2017, 11, 2),  new DateTime(2017, 11, 4), 3);

        private static readonly Lazy<Shabath[]> allShabathes = new Lazy<Shabath[]>(() => typeof(CurrentSabathes).AllStaticFields<Shabath>().ToArray());
        public static Shabath[] AllShabathes => allShabathes.Value;
    }
}
