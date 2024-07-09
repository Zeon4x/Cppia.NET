namespace Cppia.Runtime;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
public class CppiaFieldAttribute : Attribute
{
    public string Name { get; }

    public CppiaFieldAttribute(string name)
    {
        Name = name;
    }
}