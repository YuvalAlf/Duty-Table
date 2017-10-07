using MonthlyDutyTable.Time;
using MonthlyDutyTable.Roles;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources;

namespace MonthlyDutyTable.Program.DutyTableSolution
{
    public sealed class DutyTableData
    {
        public Night[] Nights { get; }
        public Soldier[] Soldiers { get; }
        public DutyTableConstraints Constraints { get; }
        public Dictionary<Night, Dictionary<Role, Soldier>> SoldierDuties { get; }
        public Dictionary<Soldier, List<Duty<Night>>> Duties { get; }
        public Dictionary<Soldier, int> GuardingAmount { get; }
        public Dictionary<Soldier, int> NotGuardingAmount { get; }

        public DutyTableData(Night[] nights,
                             Soldier[] soldiers,
                             DutyTableConstraints constraints,
                             Dictionary<Night, Dictionary<Role, Soldier>> soldierDuties,
                             Dictionary<Soldier, List<Duty<Night>>> duties,
                             Dictionary<Soldier, int> guardingAmount,
                             Dictionary<Soldier, int> notGuardingAmount)
        {
            Nights = nights;
            Soldiers = soldiers;
            Constraints = constraints;
            SoldierDuties = soldierDuties;
            Duties = duties;
            GuardingAmount = guardingAmount;
            NotGuardingAmount = notGuardingAmount;
        }

        public static DutyTableData Init(Night[] nights, Soldier[] soldiers, DutyTableConstraints constraints)
        {
            var soldierDuties = new Dictionary<Night, Dictionary<Role, Soldier>>(nights.Length);
            var duties = new Dictionary<Soldier, List<Duty<Night>>>(soldiers.Length);
            var guardingAmount = new Dictionary<Soldier, int>(soldiers.Length);
            var notGuardingAmount = new Dictionary<Soldier, int>(soldiers.Length);

            foreach (var night in nights)
                soldierDuties[night] = new Dictionary<Role, Soldier>(RoleUtils.AllRoles.Length);
            foreach (var soldier in soldiers)
            {
                duties[soldier] = new List<Duty<Night>>();
                guardingAmount[soldier] = 0;
                notGuardingAmount[soldier] = 0;
            }

            return new DutyTableData(nights, soldiers, constraints, soldierDuties, duties, guardingAmount, notGuardingAmount);
        }

        public void Add(Soldier soldier, Duty<Night> duty)
        {
            SoldierDuties[duty.DaysTime][duty.Role] = soldier;
            Duties[soldier].Add(duty);
            if (duty.IsGuarding)
                GuardingAmount[soldier]++;
            else
                NotGuardingAmount[soldier]++;
        }

        public void Remove(Soldier soldier, Duty<Night> duty)
        {
            SoldierDuties[duty.DaysTime].Remove(duty.Role);
            Duties[soldier].Remove(duty);
            if (duty.IsGuarding)
                GuardingAmount[soldier]--;
            else
                NotGuardingAmount[soldier]--;
        }
    }
}
