

using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class BaseCallInstruction : CppiaInstruction
{
    public List<CppiaInstruction> Arguments { get; } = new();

    protected void ReadArguments(CppiaFile file, CppiaReader reader, int count = -1)
    {
        if(count == -1)
            count = reader.ReadInt();
        ReadInstructions(Arguments, file, reader, count);
    }

    public object?[] GetArguments(Context context)
    {
        return Arguments.Select(a => a.Execute(context)).ToArray();
    }
}