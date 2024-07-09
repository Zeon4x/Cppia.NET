using Cppia.NET;
using Cppia.NET.Instructions;


namespace Cppia.NET;

[CppiaType("haxe.Log")]
public class Log
{
    public static Action<object, PosInfo> trace { get; set; } = DefaultTrace;

    public static void DefaultTrace(object message, PosInfo posInfo)
    {
        Console.WriteLine($"{posInfo.File}:{posInfo.Line}: {message}");
    }
}