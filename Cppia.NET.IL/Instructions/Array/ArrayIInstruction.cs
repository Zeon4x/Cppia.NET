using System.Collections;


namespace Cppia.NET.Instructions;

public class ArrayIInstruction : CppiaInstruction
{
    public string Class { get; }
    public CppiaInstruction ThisInstruction { get; }
    public CppiaInstruction InputInstruction { get; }

    public ArrayIInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        ThisInstruction = ReadInstruction(file, reader);
        InputInstruction = ReadInstruction(file, reader);
    }
}