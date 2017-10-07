using System;
using System.IO;
using System.Linq;
using System.Text;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Utils;
using MonthlyDutyTable.HumanResources;
using static MonthlyDutyTable.Roles.Role;

namespace MonthlyDutyTable.Program.DutyTableSolution
{
    public sealed partial class DutyTable
    {

        public void Print(Action<string> output)
        {
            StringBuilder str = new StringBuilder();
            foreach (var soldier in Soldiers.AsQueryable().OrderBy(s => s.Unit).ThenBy(s => s.HebrewName))
            {
                str.AppendLine(soldier.EnglishName + ":");
                foreach (var shabath in soldier.KnownShabathes)
                    str.AppendLine("\t" + shabath);
                //foreach (var night in soldier.KnownNightsDoing)
                  //  str.AppendLine("\t" + night);
                foreach (var night in Duties[soldier])
                    str.AppendLine("\t" + night);
                str.AppendLine();
            }
            output(str.ToString());
        }

        public void ToCsv(string path)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("תאריך,מרכז מידע,מגמ,משלט,תורן שומר");
            foreach (var night in Nights)
            {
                str.Append(night.DateTime.Day + ",");
                foreach (var role in RoleUtils.AllRoles)
                {
                    (Soldier s, bool isGurading) = FindSoldierAndGuarding(night, role);
                    str.Append(s.HebrewName);
                    if (isGurading)
                        str.Append(" (שמירה)");
                    str.Append(",");
                }
                str.Remove(str.Length - 1, 1);
                str.AppendLine();
            }
            File.WriteAllText(path, str.ToString(), Encoding.UTF8);
        }

        public (Soldier s, bool isGurading) FindSoldierAndGuarding(Night night, Role role)
        {
            foreach (var soldier in Soldiers)
                foreach (var duty in Duties[soldier])
                    if (duty.DaysTime.Equals(night) && duty.Role == role)
                        return (soldier, duty.IsGuarding);
            throw new Exception("Night " + night + " role " + role.AsString() + " not manned");
        }
    }
}
