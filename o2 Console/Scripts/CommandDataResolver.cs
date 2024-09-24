using System;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace InGame_Console.InGame_Console_System.Scripts
{
    public static class CommandDataResolver
    {
        public static object GetData(string value, Type type) // Parameter Type
        {
            return type.IsSubclassOf(typeof(UnityEngine.Object))
                ? Resources.Load(value)
                : Convert.ChangeType(value.Trim(), type);
        }

        public static Type GetParameterType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Event:
                    return ((EventInfo)member).EventHandlerType;
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Method:
                    var method = (MethodInfo)member;
                    var parameters = method.GetParameters();
                    if (parameters.Length > 1)
                        throw new Exception("Method can only have one parameter");
                    return parameters.Length == 0 ? null : parameters[0].ParameterType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException
                    (
                        "Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo"
                    );
            }
        }

        public static (string Command, string DataKey) ParseRawCommand(string command)
        {
            var split = RemoveRichTextTags(command).Replace("(", "").Replace(")", "").Split(":");
            return split.Length == 2 ? (split[0], split[1]) : (split[0], null);
        }

        public static string RemoveRichTextTags(string input)
        {
            // Tüm Rich Text taglarını temizler
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}