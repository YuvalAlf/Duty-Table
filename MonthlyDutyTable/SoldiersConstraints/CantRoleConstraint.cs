using MonthlyDutyTable.Roles;
using MonthlyDutyTable.Time;

namespace MonthlyDutyTable.SoldiersConstraints
{
    public sealed class CantRoleConstraint : Constraint
    {
        public Role Role { get; }

        public CantRoleConstraint(Role role)
        {
            Role = role;
        }

        public override bool IsSatasfied(Duty<Night> duty)
        {
            return duty.Role != this.Role;
        }
    }
}
