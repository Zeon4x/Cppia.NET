using System.Security.Cryptography.X509Certificates;
using Cppia;
using Cppia.Runtime;

namespace Cppia.Std;
public class Type
{
    public static CppiaEnumConstructor[] AllEnums(CppiaEnum @enum)
    {
        return @enum.Constructors.ToArray();
    }

    public static object CreateInstance(IClass @class, object[] parameters)
        => @class.Construct(parameters);

    // Supports only interpreted classes
    public static object CreateEmptyInstance(InterpretedClass @class)
        => new CppiaInstance(@class);

    public static EnumValue CreateEnum(CppiaEnum @enum, string constructorName, object[] parameters)
    {
        if (@enum.GetConstructor(constructorName) is not CppiaEnumConstructor constructor)
            throw new Exception($"Constructor {constructorName} not found in enum {@enum.Name}");
        var index = @enum.Constructors.IndexOf(constructor);
        return new EnumValue(@enum, index, constructor, parameters);
    }

    public static EnumValue CreateEnumIndex(CppiaEnum @enum, int constructorIndex, object[] parameters)
    {
        var constructor = @enum.Constructors[constructorIndex];
        var index = @enum.Constructors.IndexOf(constructor);
        return new EnumValue(@enum, index, constructor, parameters);
    }

    public static string EnumConstructor(EnumValue enumValue) => enumValue.Name;

    public static bool EnumEq(EnumValue a, EnumValue b)
    {
        return a.Name == b.Name && !a.Properties.Except(b.Properties).Any();
    }

    public static int EnumIndex(EnumValue enumValue) => enumValue.Index;

    public static object?[] EnumParameters(EnumValue enumValue)
        => enumValue.Properties.Values.ToArray();

    public static IClass GetClass(object? obj)
    {
        if (obj is CppiaInstance instance)
            return instance.Class;
        throw new NotImplementedException();
    }

    public static string[] GetClassFields(IClass @class) => throw new NotImplementedException();
    public static string[] GetInstanceFields(IClass @class) => throw new NotImplementedException();

    public static string GetClassName(IClass @class) => @class.Name;
    public static CppiaEnum GetEnum(EnumValue enumValue) => enumValue.Enum;
    public static string[] GetEnumConstructs(CppiaEnum @enum)
        => @enum.Constructors.Select(c => c.Name).ToArray();
    public static string GetEnumName(CppiaEnum @enum) => @enum.Name;
    public static IClass? GetSuperClass(IClass @class) => @class.BaseClass;
}