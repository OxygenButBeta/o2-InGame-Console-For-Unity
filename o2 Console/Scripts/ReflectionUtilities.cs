using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InGame_Console.InGame_Console_System.Scripts
{
    public static class ReflectionUtilities
    {
        // ReSharper disable once TooManyDeclarations
        public static IEnumerable<(MemberInfo memberInfo, T attribute)> FindAllMembersByAttribute<T>(
            BindingFlags flags)
            where T : Attribute
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .SelectMany(type => GetMembersByAttribute<T>(flags, type));
        }

        public static IEnumerable<(MemberInfo memberInfo, T attribute)> GetMembersByAttribute<T>(
            BindingFlags flags, Type client)
            where T : Attribute
        {
            return client.GetMembers(flags)
                .Select(memberInfo => (memberInfo, memberInfo.GetCustomAttribute<T>()))
                .Where(tuple => tuple.Item2 != null);
        }
    }
}