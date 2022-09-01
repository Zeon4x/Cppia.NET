using Cppia.NET;
using Cppia.NET.Runtime;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class FunctionInstruction : CppiaInstruction
{
    public string ReturnType { get; }
    public List<CppiaArgument> Arguments { get; } = new();

    public CppiaInstruction Body { get; }

    public FunctionInstruction(CppiaFile file, CppiaReader reader)
    {
        ReturnType = file.Types[reader.ReadByte()];

        int count = reader.ReadByte();
        for (int i = 0; i < count; i++)
            Arguments.Add(new CppiaArgument(file,reader));

        Body = ReadInstruction(file, reader);
    }

    public object? Invoke(Context context)
    {
        var value = Body.Execute(context);
        if(value is ReturnResult returnResult )
            return returnResult.Value;
        return null;
    }

    public override object? Execute(Context context)
    {
        return new CppiaFunction(this, context.Runtime);
    }
}