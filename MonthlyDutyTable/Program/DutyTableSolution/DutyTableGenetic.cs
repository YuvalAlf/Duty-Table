using System;
using System.Text;
using System.Linq;
using MonthlyDutyTable.Time;
using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Utils;
using System.Collections.Generic;
using MonthlyDutyTable.HumanResources;
using MonthlyDutyTable.HumanResources.Units;

namespace MonthlyDutyTable.Program.DutyTableSolution
{
    public sealed partial class DutyTable
    {
        public static int CalcNegativePrice(Night[] nights,
                                            Soldier[] soldiers,
                                            DutyTableConstraints constraints,
                                            Dictionary<Night, Dictionary<Role, Soldier>> soldierDuties,
                                            Dictionary<Soldier, List<Duty<Night>>> duties,
                                            Dictionary<Soldier, int> guardingAmount,
                                            Dictionary<Soldier, int> notGuardingAmount)
        {
            int negativePrice = 0;
            foreach (var soldier in soldiers)
            {
                negativePrice += (guardingAmount[soldier] - soldier.NightsGuardingAmount).Square();
                negativePrice += (notGuardingAmount[soldier] - soldier.NightsNotGuardingAmount).Square();
                negativePrice +=
                    duties[soldier]
                        .Select(d => d.DaysTime)
                        .OrderBy(x => x)
                        .Pairwise((d1, d2) => d1.DistanceTo(d2))
                        .Where(d => d <= constraints.MinRangeBetweenNights)
                        .Sum(d => (1 + constraints.MinRangeBetweenNights - d).Square());
                foreach(var shabath in soldier.KnownShabathes.Select(s => s.DaysTime))
                    foreach(var night in duties[soldier].Select(nd => nd.DaysTime))
                        if (shabath.DistanceTo(night) <= constraints.MinRangeShabath)
                            negativePrice += (1 + constraints.MinRangeShabath - shabath.DistanceTo(night)).Square();
            }
            return negativePrice;
        }

        public string NegativePriceExplanation()
        {
            StringBuilder explanation = new StringBuilder();
            foreach (var soldier in Soldiers)
            {
                if (GuardingAmount[soldier] != soldier.NightsGuardingAmount)
                    explanation.AppendLine($"Soldier {soldier.EnglishName} guards {GuardingAmount[soldier]} times instead of {soldier.NightsGuardingAmount} times");
                if (NotGuardingAmount[soldier] != soldier.NightsNotGuardingAmount)
                    explanation.AppendLine($"Soldier {soldier.EnglishName} not-guarding-nights {NotGuardingAmount[soldier]} times instead of {soldier.NightsNotGuardingAmount} times");
                foreach (var night1 in Duties[soldier].Select(d => d.DaysTime))
                    foreach (var night2 in Duties[soldier].Select(d => d.DaysTime))
                        if (!night1.Equals(night2))
                            if (night1.DistanceTo(night2) <= Constraints.MinRangeBetweenNights)
                                explanation.AppendLine($"Soldier {soldier.EnglishName} has a night at {night1.DateTime.Day} and at {night2.DateTime.Day}");
                foreach (var shabath in soldier.KnownShabathes.Select(s => s.DaysTime))
                    foreach (var night in Duties[soldier].Select(nd => nd.DaysTime))
                        if (shabath.DistanceTo(night) <= Constraints.MinRangeShabath)
                            explanation.AppendLine($"Soldier {soldier.EnglishName} has a Shabath at {shabath.StartingTime}-{shabath.EndingTime} and a night at {night.DateTime.Day}");
            }
            return explanation.ToString();
        }

        public string Validate()
        {
            StringBuilder validation = new StringBuilder();
            /*foreach (var night in Nights)
                foreach (var role in RoleUtils.AllRoles)
                    if (SoldierDuties[night].ContainsKey(role) == false)
                        validation.AppendFormat("Does not contain role {0} at night {1}\n", role.AsString(), night.DayNum);
            foreach(var soldier in Soldiers)
                foreach(var duty in Duties[soldier])
                    if (SoldierDuties[duty.Night][duty.Role].Equals(soldier) == false)
                        validation.AppendFormat("Inconsistency at night {0} at role {1}\n", duty.Night.DayNum, duty.Role.AsString());
            foreach (var night in Nights)
                foreach (var role in RoleUtils.AllRoles)
                    if (Duties[SoldierDuties[night][role]].Exists(d => d.Night.Equals(night) && d.Role == role) == false)
                        validation.AppendFormat("Inconsistency at night {0} at role {1}\n", night.DayNum, role.AsString());
            foreach (var night in Nights)
                foreach (var unitGroup in SoldierDuties[night].Values.GroupBy(s => s.Unit))
                {
                    var unit = unitGroup.Key;
                    var numOfSoldiersInNight = unitGroup.Count();
                    var maxSoldiersAllowed = Constraints.MaxSoldiersOfUnit[unit];
                    if (numOfSoldiersInNight > maxSoldiersAllowed)
                        validation.AppendFormat("Night {0} has {1} soldiers of unit {2}\n", night, numOfSoldiersInNight, unit.AsString());
                }
            foreach (var night in Nights)
                foreach (var soldierGroup in SoldierDuties[night].Values.GroupBy(s => s))
                    if (soldierGroup.Count() > 1)
                        validation.AppendFormat("Night {0} has {1} times the soldeir {2}\n", night, soldierGroup.Count(), soldierGroup.Key);*/
            return validation.ToString();
        }

        public DutyTable MateMutate(DutyTable otherDutyTable, double mutationRate, Random rnd)
        {
            DutyTable mom = this;
            DutyTable dad = otherDutyTable;
            DutyTableData son = Mate(mom, dad, Constraints, rnd);
            if (rnd.NextDouble() < mutationRate)
                Mutate(son, Constraints, rnd);
            return DutyTable.Create(son);
        }

        private static void Mutate(DutyTableData dutyTable, DutyTableConstraints constraints, Random rnd)
        {
            var exceedingSoldier =
                dutyTable
                .Soldiers
                .Where(s => !s.IsDone)
                .AllWithMax(s => dutyTable.Duties[s].Count - s.NightsGuardingAmount - s.NightsNotGuardingAmount)
                .ChooseRandomly(rnd);
            
            var duty =
                dutyTable
                .Duties[exceedingSoldier]
                .Where(d => !exceedingSoldier.KnownNightsDoing.Contains(d))
                .ToArray()
                .ChooseRandomly(rnd);

            Soldier minusSoldier =
                dutyTable.Soldiers
                    .Where(s => s.CanDo(duty, dutyTable.Duties, dutyTable.SoldierDuties, constraints) || s.Equals(exceedingSoldier))
                    .AllWithMax(s => duty.IsGuarding ? s.NightsGuardingAmount - dutyTable.GuardingAmount[s] : s.NightsNotGuardingAmount - dutyTable.NotGuardingAmount[s])
                    .ChooseRandomly(rnd);

            if (!exceedingSoldier.Equals(minusSoldier))
            {
                dutyTable.Remove(exceedingSoldier, duty);
                dutyTable.Add(minusSoldier, duty);
            }
        }


        private static DutyTableData Mate(DutyTable mom, DutyTable dad, DutyTableConstraints constraints, Random rnd)
        {
            var nights = mom.Nights;
            var soldiers = mom.Soldiers;
            var data = DutyTableData.Init(nights, soldiers, constraints);

            int pivotAmount = rnd.Next(1, nights.Length - 1);

            for (int i = 0; i < nights.Length; i++)
            {
                var night = nights[i];
                var parent = i < pivotAmount ? mom : dad;
                foreach (var role in RoleUtils.AllRoles)
                {
                    var soldier = parent.SoldierDuties[night][role];
                    var duty = parent.Duties[soldier].First(n => n.DaysTime.Equals(night));
                    data.Add(soldier, duty);
                }
            }

            return data;
        }
    }
}
