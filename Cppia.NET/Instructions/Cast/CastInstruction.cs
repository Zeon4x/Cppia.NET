using Cppia.Runtime;

namespace Cppia.Instructions;

public class CastInstruction : CppiaInstruction
{
    public CastOpCode OpCode { get; }
    public string? Type { get; }
    public CppiaInstruction Value { get; }

    public CastInstruction(CppiaFile file, CppiaReader reader, CastOpCode opCode)
    {
        OpCode = opCode;
        if(opCode == CastOpCode.CastDataArray || opCode == CastOpCode.CastInstance)
            Type = file.Types[reader.ReadInt()];
        Value = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context) => Value.Execute(context);

    public enum CastOpCode : byte
    {
        CastNOP,
        CastDynamic,
        CastInstance,
        CastDataArray,
        CastDynArray,
        CastInt,
        CastBool,
        CastFloat,
        CastString,
    }
}