using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace InGame_Console.InGame_Console_System.Scripts
{
    public static class ConsoleDatabase
    {
        const BindingFlags Staticflags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        const BindingFlags InstanceFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        static readonly Dictionary<string, CommandProviderInfo> membersDict =
            new(StringComparer.OrdinalIgnoreCase);

        static readonly Dictionary<string, (MonoBehaviour obj, CommandProviderInfo info)> instanceMembersDict =
            new(StringComparer.OrdinalIgnoreCase);

        public static IReadOnlyCollection<string> GetAllCommands()
        {
            var keys = new List<string>();
            keys.AddRange(membersDict.Keys);

            var copy = instanceMembersDict.ToArray();
            foreach (var kvp in copy)
                if (kvp.Value.obj != null)
                    keys.Add(kvp.Key);
                else if (kvp.Value.obj == null) instanceMembersDict.Remove(kvp.Key);

            return keys;
        }


        public static CommandProviderInfo GetCommand(string key)
        {
            if (membersDict.TryGetValue(key, out var value)) return value;
            return instanceMembersDict.TryGetValue(key, out var instanceValue) ? instanceValue.info : null;
        }

        public static Type GetCommandType(string key)
        {
            return GetCommand(key).Member.GetParameterType();
        }

        public static void RegisterClient(MonoBehaviour client)
        {
            foreach (var pair in ReflectionUtilities.GetMembersByAttribute<ConsoleCommandAttribute>(InstanceFlags,
                         client.GetType()))
            {
                var key =
                    $"[Instance | {client.gameObject.GetInstanceID()}].{pair.attribute.Key}";
                if (instanceMembersDict.ContainsKey(key))
                {
                    Debug.LogWarning(
                        $"Command with key {key} already exists, skipping command registration for {pair.memberInfo.Name}");
                    continue;
                }

                instanceMembersDict.Add(key, (client, new CommandProviderInfo(pair.memberInfo, client)));
                Debug.Log($"Command {key} registered successfully");
            }
        }

        [RuntimeInitializeOnLoadMethod]
        static void init()
        {
            foreach (var pair in ReflectionUtilities.FindAllMembersByAttribute<ConsoleCommandAttribute>(Staticflags))
                membersDict.Add(pair.attribute.Key, new CommandProviderInfo(pair.memberInfo, null));
        }
    }
}