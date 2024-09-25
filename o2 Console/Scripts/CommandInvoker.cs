using System.Reflection;
using UnityEngine;

namespace InGame_Console.InGame_Console_System.Scripts
{
    public static class CommandInvoker
    {
        public static void InvokeCommand(string command, string DataKey = null)
        {
            var targetMember = ConsoleDatabase.GetCommand(command);
            if (targetMember is null)
            {
                Debug.LogWarning($"Command \"{command} \" is not found.");
                return;
            }


            var paramType = targetMember.Member.GetParameterType();
            var data = paramType != null ? CommandDataResolver.GetData(DataKey, paramType) : null;
            InvokeMember(targetMember, data);
        }

        static void InvokeMember(CommandProviderInfo targetMember, object data)
        {
            var member = targetMember.Member;
            var client = targetMember.Client;
            switch (member)
            {
                case MethodInfo methodInfo:
                    methodInfo.Invoke(client, data != null ? new[] { data } : null);
                    break;
                case PropertyInfo propertyInfo:
                    propertyInfo.SetValue(client, data);
                    break;
                case FieldInfo fieldInfo:
                    fieldInfo.SetValue(client, data);
                    break;
            }
        }
    }
}