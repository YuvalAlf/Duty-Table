using System;
using System.Linq;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Utils;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources;
using MonthlyDutyTable.GeneticAlgorithm;

namespace MonthlyDutyTable.Program.DutyTableSolution
{
    public sealed partial class DutyTable : IGeneticSolution<DutyTable>
    {
        public int NegativePrice { get; }
        public Night[] Nights { get; }
        public Soldier[] Soldiers { get; }
        public DutyTableConstraints Constraints { get; }
        public Dictionary<Night, Dictionary<Role, Soldier>> SoldierDuties { get; }
        public Dictionary<Soldier, List<Duty<Night>>> Duties { get; }
        public Dictionary<Soldier, int> GuardingAmount { get; }
        public Dictionary<Soldier, int> NotGuardingAmount { get; }

        public DutyTable(int negativePrice,
                         Night[] nights,
                         Soldier[] soldiers,
                         DutyTableConstraints constraints,
                         Dictionary<Night, Dictionary<Role, Soldier>> soldierDuties,
                         Dictionary<Soldier, List<Duty<Night>>> duties,
                         Dictionary<Soldier, int> guardingAmount,
                         Dictionary<Soldier, int> notGuardingAmount)
        {
            NegativePrice = negativePrice;
            Nights = nights;
            Soldiers = soldiers;
            Constraints = constraints;
            SoldierDuties = soldierDuties;
            Duties = duties;
            GuardingAmount = guardingAmount;
            NotGuardingAmount = notGuardingAmount;
        }

        public static DutyTable Create(Night[] nights,
                                       Soldier[] soldiers,
                                       DutyTableConstraints constraints,
                                       Dictionary<Night, Dictionary<Role, Soldier>> soldierDuties,
                                       Dictionary<Soldier, List<Duty<Night>>> duties,
                                       Dictionary<Soldier, int> guardingAmount,
                                       Dictionary<Soldier, int> notGuardingAmount)
        {
            int negativePrice = CalcNegativePrice(nights, soldiers, constraints, soldierDuties, duties, guardingAmount, notGuardingAmount);
            return new DutyTable(negativePrice, nights, soldiers, constraints, soldierDuties, duties, guardingAmount, notGuardingAmount);
        }

        public static DutyTable Create(DutyTableData d)
        {
            return DutyTable.Create(d.Nights, d.Soldiers, d.Constraints, d.SoldierDuties, d.Duties, d.GuardingAmount, d.NotGuardingAmount);
        }


        public static DutyTable TryGenRandomly(Night[] nights, Soldier[] soldiers, DutyTableConstraints constraints,
            Random rnd, int times)
        {
            for (int i = 0; i < times - 1; i++)
                try
                {
                    return GenRandomly(nights, soldiers, constraints, rnd);
                }
                catch
                {
                    // ignored
                }
            return GenRandomly(nights, soldiers, constraints, rnd);
        }

        private static DutyTable GenRandomly(Night[] nights, Soldier[] soldiers, DutyTableConstraints constraints, Random rnd)
        {
            var data = DutyTableData.Init(nights, soldiers, constraints);
            var guardingAmountsRemaining = new Dictionary<Night, int>(nights.Length);
            var guardingDuties = new Dictionary<Night, Dictionary<Role, bool>>(nights.Length);

            Action<Night, Role> tryMakeRoleGuarding = (night, role) =>
            {
                if (guardingDuties[night][role] == false)
                {
                    guardingDuties[night][role] = true;
                    guardingAmountsRemaining[night]--;
                }
            };

            foreach (var night in nights)
            {
                guardingAmountsRemaining[night] = night.GuardingAmount;
                guardingDuties[night] = new Dictionary<Role, bool>(RoleUtils.AllRoles.Length);
                foreach (var role in RoleUtils.AllRoles)
                    guardingDuties[night][role] = false;
                tryMakeRoleGuarding(night, Role.ToranShomer1);
                if (!NoOne.Soldier.KnownNightsDoing.Any(d => d.DaysTime.Equals(night)))
                    tryMakeRoleGuarding(night, Role.ToranShomer2);
            }

            
            foreach (var soldier in soldiers)
                foreach (var nightDuty in soldier.KnownNightsDoing)
                {
                    data.Add(soldier, nightDuty);
                    if (nightDuty.IsGuarding)
                        tryMakeRoleGuarding(nightDuty.DaysTime, nightDuty.Role);
                }
            foreach (var night in nights)
            {
                while (guardingAmountsRemaining[night] > 0)
                {
                    var role = RoleUtils.AllRolesNoToranShomer.ChooseRandomly(rnd);
                    if (data.SoldierDuties[night].ContainsKey(role) == false)
                        tryMakeRoleGuarding(night, role);
                }
                foreach (var role in RoleUtils.AllRoles)
                    if (data.SoldierDuties[night].ContainsKey(role) == false)
                    {
                        var nightDuty = night.Duty(guardingDuties[night][role], role);
                        var soldier =
                            soldiers
                            .Where(s => s.CanDo(nightDuty, data.Duties, data.SoldierDuties, constraints))
                            .AllWithMax(s => nightDuty.IsGuarding ? s.NightsGuardingAmount - data.GuardingAmount[s] : s.NightsNotGuardingAmount - data.NotGuardingAmount[s])
                            .ChooseRandomly(rnd);
                        data.Add(soldier, nightDuty);
                    }
            }

            return DutyTable.Create(data);
        }
    }
}
