using Cppia.Runtime;

namespace Cppia.Std;

public class CppiaStd
{
    public static bool IsOfType(object value, IClass @class) {
		if(value is CppiaInstance instance)
            return instance.Class.IsOfType(@class);
        if(@class is NativeClass nativeClass)
            return nativeClass.IsOfType(value.GetType());
        return false;
    }

    public static string String(object? value)
    {
        return value is null ? "null" : value?.ToString()!;
    }

    public static int Int(double value) => Convert.ToInt32(value);
    public static int ParseInt(string value) => int.Parse(value);
    public static float ParseFloat(string value) => float.Parse(value);
    public static int Random(int value) =>new Random().Next(value);

}