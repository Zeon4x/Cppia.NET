

using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

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

    public override object? Emit(ILProcessor processor, Context context)
    {
        if(Body is BlockInstruction block)
        {
            if(block.Instructions.LastOrDefault() is not ReturnInstruction)
                block.Instructions.Add(new ReturnInstruction());
        }
        Body.Emit(processor, context);
        return null;
    }
}