using Cppia.Instructions;
using Cppia.Runtime;

namespace Cppia;

public class Log
{
    public static NativeMethod? Trace { get; set; } = new NativeMethod(typeof(Log).GetMethod(nameof(DefaultTrace))!);

    public static void DefaultTrace(object message, PosInfoInstruction posInfoInstruction)
    {
        Console.WriteLine(posInfoInstruction.File + ":" + posInfoInstruction.Line + ": " + message);
    }
}