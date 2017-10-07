using System.Runtime.CompilerServices;

namespace MonthlyDutyTable.Utils
{
    public static class IntUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Square(this int @this) => @this * @this;
    }
}
