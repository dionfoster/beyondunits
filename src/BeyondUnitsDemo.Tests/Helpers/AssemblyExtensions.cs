using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeyondUnitsDemo.Tests.Helpers
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesWithBaseType<T>(this Assembly assembly)
        {
            return assembly.GetTypes()
                           .Where(o => GetBaseTypes(o).Contains(typeof (T)))
                           .OrderBy(o => o.FullName);
        }

        static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            if (type.BaseType == null) return type.GetInterfaces();

            return Enumerable.Repeat(type.BaseType, 1)
                             .Concat(type.GetInterfaces())
                             .Concat(type.GetInterfaces().SelectMany(GetBaseTypes))
                             .Concat(type.BaseType.GetBaseTypes());
        }

        public static IEnumerable<Type> WithAttribute<T>(this IEnumerable<Type> types)
            where T : Attribute
        {
            return types.Where(t => t.IsDefined(typeof (T), true));
        }

        public static IEnumerable<Type> WithoutAttribute<T>(this IEnumerable<Type> types)
            where T : Attribute
        {
            return types.Where(t => !t.IsDefined(typeof (T), true));
        }
    }
}