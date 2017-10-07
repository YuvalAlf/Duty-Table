using System.Collections.Generic;
using MonthlyDutyTable.HumanResources.Units;
using MonthlyDutyTable.SoldiersConstraints;

namespace MonthlyDutyTable.Program.DutyTableSolution
{
    public sealed class DutyTableConstraints
    {
        public int MinRangeBetweenNights { get; }
        public int MinRangeShabath { get; }
        public Dictionary<Unit, int> MaxSoldiersOfUnit { get; }
        public Dictionary<Unit, Constraint[]> UnitConstraints { get; }

        public DutyTableConstraints(int minRangeBetweenNights, int minRangeShabath, Dictionary<Unit, int> maxSoldiersOfUnit, Dictionary<Unit, Constraint[]> unitConstraints)
        {
            MinRangeBetweenNights = minRangeBetweenNights;
            MinRangeShabath = minRangeShabath;
            MaxSoldiersOfUnit = maxSoldiersOfUnit;
            UnitConstraints = unitConstraints;
        }
    }
}
