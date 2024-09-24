using System.Reflection;

namespace InGame_Console.InGame_Console_System.Scripts
{
    public class CommandProviderInfo
    {
        internal readonly MemberInfo Member;
        internal readonly object Client;

        public CommandProviderInfo(MemberInfo member, object client)
        {
            Member = member;
            Client = client;
        }
    }
}