using Cppia.Instructions;
using Cppia.Runtime;

namespace Cppia;

public class Log
{
    public static Action<object, PosInfoInstruction> Trace { get; set; } = DefaultTrace;

    public static void DefaultTrace(object message, PosInfoInstruction posInfo)
    {
        if(message is CppiaInstance instance)
        {
            IMethod? method = instance.Class?.GetMethod("toString");
            Console.WriteLine($"{posInfo.File}:{posInfo.Line}: {method?.Invoke(instance)}");
        }
        else
            Console.WriteLine($"{posInfo.File}:{posInfo.Line}: {message}");
    }
}