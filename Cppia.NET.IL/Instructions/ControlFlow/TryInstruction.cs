using System.Diagnostics;


namespace Cppia.NET.Instructions;

public class TryInstruction : CppiaInstruction
{
    public CppiaInstruction Body { get; }
    public List<CppiaCatch> Catches { get; } = new();

    public TryInstruction(CppiaFile file, CppiaReader reader) 
    {
        int catchCount = reader.ReadInt();
        Body = ReadInstruction(file, reader);
        for (int i = 0; i < catchCount; i++)
            Catches.Add(new CppiaCatch(file, reader));
    }

    

    public struct CppiaCatch
    {
        public CppiaLocalVarible Varible { get; }
        public CppiaInstruction Body { get; }

        public CppiaCatch(CppiaFile file, CppiaReader reader)
        {
            Varible = new CppiaLocalVarible(file, reader);
            Body = CppiaInstruction.ReadInstruction(file, reader);
        }
    }
}