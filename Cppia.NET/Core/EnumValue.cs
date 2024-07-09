using System.Diagnostics.CodeAnalysis;

namespace Cppia.Runtime;

public struct EnumValue
{
    public int Index { get; }

    public string Name { get; }

    public CppiaEnum Enum { get; }

    public Dictionary<int, object?> Properties { get; } = new();

    public EnumValue(CppiaEnum @enum, int index, CppiaEnumConstructor constructor, params object?[] parameters)
    {
        Index = index;
        Name = constructor.Name;
        Enum = @enum;
        
        for (int i = 0; i < parameters.Length; i++)
            Properties[i] =  parameters[i];                                                                                                                                       
    }

    [CppiaField("__Index")]
    public int GetIndex() => Index;

}