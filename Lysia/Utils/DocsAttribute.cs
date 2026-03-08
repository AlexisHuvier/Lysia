using System;

namespace Lysia.Utils;

[AttributeUsage(AttributeTargets.Class)]
public class DocsAttribute(string name, string description): Attribute
{
    public string Name { get; } = name;
    public string Description { get; } = description;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DocsExampleAttribute(string code, string result): Attribute
{
    public string Code { get; } = code;
    public string Result { get; } = result;
}