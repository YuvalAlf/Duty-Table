using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MonthlyDutyTable.Utils
{
    public static class TypeUtils
    {
        public static IEnumerable<T> AllStaticFields<T>(this Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
                if (field.FieldType == typeof(T))
                    yield return (T)field.GetValue(null);
        }

        public static void InitializeTypes(this Assembly @this)
        {
            foreach(var type in @this.GetTypes())
                RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        }
    }
}
