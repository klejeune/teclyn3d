
using System;
using System.Collections.Generic;
using System.Linq;

public static class TypeTools
{
    public static IEnumerable<Type> GetAllAncestors(this Type type)
    {
        var typeInfo = type;

        if (typeInfo.BaseType == typeof(object) || typeInfo.BaseType == null)
        {
            return type.AsArray();
        }
        else
        {
            return type.AsArray().Union(GetAllAncestors(typeInfo.BaseType));
        }
    }

    public static IEnumerable<Type> GetAllAncestorsAndInterfaces(this Type type)
    {
        return type.GetInterfaces().Union(GetAllAncestors(type)).ToList();
    }
}
