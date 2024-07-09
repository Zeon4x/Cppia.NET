using Cppia.NET.Instructions;

namespace Cppia;

public class CppiaField : CppiaMember
{
    public string Name { get; }
    public string Type { get; }
    public bool IsVirtual { get; }
    public Access ReadAcess { get; }
    public Access WriteAccess { get; }
    public CppiaInstruction? Init { get; }

    public CppiaField(CppiaFile file, CppiaReader reader) 
        : base(file, reader)
    {
        ReadAcess = GetAccess(reader);
        WriteAccess = GetAccess(reader);
        IsVirtual = reader.ReadBoolean();
        Name = file.Strings[reader.ReadInt()];
        Type  = file.Types[reader.ReadInt()];
        if(reader.ReadBoolean())
            Init = CppiaInstruction.ReadInstruction(file, reader);
    }

    private Access GetAccess(CppiaReader reader)
    {
        var code = reader.ReadByte();
        if(code >= 69 && code <= 72)
            return (Access)(code - 69);
        throw new InvalidDataException($"Invalid access code: {code}");
    }

    public enum Access : byte
    {
        Normal,
        Not,
        Resolve,
        Call,
        CallNative
    } 
}