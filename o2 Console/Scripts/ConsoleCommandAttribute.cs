using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
public sealed class ConsoleCommandAttribute : Attribute
{
    public readonly string Key;

    public ConsoleCommandAttribute(string key)
    {
        Key = key;
    }
}