using System;
using System.Linq;

namespace MonthlyDutyTable.Roles
{
    public static class RoleUtils
    {
        public static Role[] AllRoles = {Role.InfoCenter, Role.Magam, Role.Mashlat, Role.ToranShomer1, Role.ToranShomer2};
        public static Role[] AllRolesNoToranShomer = { Role.InfoCenter, Role.Magam, Role.Mashlat };
        public static Role[] ToranShomerOnly = { Role.ToranShomer1, Role.ToranShomer2 };
        public static Role[] Without(this Role[] roles, Role role) => roles.Where(r => r != role).ToArray();
        public static bool MustGuard(this Role role) => role == Role.ToranShomer1 || role == Role.ToranShomer2;
        public static string AsString(this Role role)
        {
            switch (role)
            {
                case Role.InfoCenter:
                    return "InfoCenter";
                case Role.Magam:
                    return "Magam";
                case Role.Mashlat:
                    return "Mashlat";
                case Role.ToranShomer1:
                    return "ToranShomer1";
                case Role.ToranShomer2:
                    return "ToranShomer2";
                default:
                    throw new Exception("Switch unhandled case");
            }
        }
    }

}
