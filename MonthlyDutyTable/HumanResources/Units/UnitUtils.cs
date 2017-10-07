using System;

namespace MonthlyDutyTable.HumanResources.Units
{
    public static class UnitUtils
    {
        public static string AsString(this Unit @this)
        {
            switch (@this)
            {
                case Unit.Unit9:
                    return "Unit9";
                case Unit.Unit11:
                    return "Unit11";
                case Unit.Unit209:
                    return "Unit209";
                case Unit.Unit474:
                    return "Unit474";
                case Unit.Unit679:
                    return "Unit679";
                case Unit.Mafog:
                    return "Mafog";
                case Unit.Merhavim:
                    return "Merhavim";
                case Unit.Ahuda:
                    return "Ahuda";
                case Unit.NoUnit:
                    return "";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
