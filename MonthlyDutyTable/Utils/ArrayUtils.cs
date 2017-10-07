using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MonthlyDutyTable.Utils
{
    public static class ArrayUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Copy<T>(this T[] @this) => @this.Clone() as T[];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] CreateArray<T>(params T[] items) => items;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ChooseRandomly<T>(this T[] @this, Random rnd) => @this[rnd.Next(@this.Length)];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ChooseRandomly<T>(this List<T> @this, Random rnd) => @this[rnd.Next(@this.Count)];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Singleton<T>(this T @this) => CreateArray(@this);
    }
}
