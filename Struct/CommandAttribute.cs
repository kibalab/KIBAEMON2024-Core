﻿namespace KIBAEMON2024_Core.Struct;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class CommandAttribute(string group = "", string description = "", params string[] alias) : Attribute
{
    public string[] Alias { get; } = alias;
    public string Group { get; } = group;
    public string Description { get; } = description;
}