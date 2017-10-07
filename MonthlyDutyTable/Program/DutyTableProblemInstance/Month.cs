using System;
using System.Linq;
using System.Text;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Roles;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources;
using MonthlyDutyTable.Program.DutyTableSolution;

namespace MonthlyDutyTable.Program.DutyTableProblemInstance
{
    public abstract class Month
    {
        public string Name { get; }
        public Soldier[] Soldiers { get; }
        public Night[] Nights { get; }
        public Shabath[] Shabathes { get; }

        protected Month(string name, Soldier[]  soldiers, Night[] nights, Shabath[] shabathes)
        {
            Name = name;
            Soldiers = soldiers;
            Nights = nights;
            Shabathes = shabathes;
        }

        public string ValidateSettings()
        {
            StringBuilder validation = new StringBuilder();
            var nightsGuardingAmount = Soldiers.Sum(s => s.NightsGuardingAmount);
            var nightsNotGuardingAmount = Soldiers.Sum(s => s.NightsNotGuardingAmount);

            var guardingNightDuties = Nights.Sum(n => n.GuardingAmount);
            var notGuardingNightDuties = Nights.Sum(n => RoleUtils.AllRoles.Length - n.GuardingAmount);

            if (nightsGuardingAmount != guardingNightDuties)
                validation.AppendFormat("Nights guarding amount has to be {0} but soldiers say {1}\n", guardingNightDuties, nightsGuardingAmount);
            if (nightsNotGuardingAmount != notGuardingNightDuties)
                validation.AppendFormat("Nights not guarding amount has to be {0} but soldiers say {1}\n", notGuardingNightDuties, nightsNotGuardingAmount);

            foreach(var shabath in Shabathes)
                foreach(var role in RoleUtils.AllRoles)
                {
                    var numOfSoldiers = Soldiers.Count(s => s.KnownShabathes.Any(l => l.DaysTime.Equals(shabath) && l.Role == role));
                    if (numOfSoldiers != 1)
                        validation.AppendFormat("period {0} with role {1} has {2} soldiers..\n", shabath, role.AsString(), numOfSoldiers);
                }


            return validation.ToString();
        }

        public string AsCsvData(DutyTable dutyTable)
        {
            StringBuilder str = new StringBuilder();
            var asString = new Func<Tuple<bool, Soldier>, string>(t => t.Item2.HebrewName + (t.Item1 ? " (שומר)" : ""));
            var duties = new Dictionary<TimePeriod, Dictionary<Role, Tuple<bool, Soldier>>>();
            foreach (var night in Nights)
                duties[night] = new Dictionary<Role, Tuple<bool, Soldier>>();
            foreach (var longPeriod in Shabathes)
                duties[longPeriod] = new Dictionary<Role, Tuple<bool, Soldier>>();
            foreach (var soldier in Soldiers)
                foreach (var nightDuty in dutyTable.Duties[soldier])
                    duties[nightDuty.DaysTime][nightDuty.Role] = Tuple.Create(nightDuty.IsGuarding, soldier);
            foreach (var soldier in Soldiers)
                foreach (var shabath in soldier.KnownShabathes)
                    duties[shabath.DaysTime][shabath.Role] = Tuple.Create(shabath.IsGuarding, soldier);
            str.AppendLine("תאריך,תקן שמירה,מרכז מידע,מגמ,משלט,תורן שומר 1, תורן שומר 2");
            foreach (var time in duties.Keys.OrderBy(x => x))
                str.Append(time).Append(',')
                    .Append(time.GuardingAmount).Append(',')
                    .Append(asString(duties[time][Role.InfoCenter])).Append(',')
                    .Append(asString(duties[time][Role.Magam])).Append(',')
                    .Append(asString(duties[time][Role.Mashlat])).Append(',')
                    .Append(asString(duties[time][Role.ToranShomer1])).Append(',')
                    .Append(asString(duties[time][Role.ToranShomer2])).AppendLine();
            return str.ToString();
        }
    }
}
