using System.Diagnostics;
using Cppia.Runtime;

namespace Cppia.Instructions;

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

    public override object? Execute(Context context)
    {
        try
        {
            Body.Execute(context);
        }
        catch(Exception exception)
        {
            foreach (CppiaCatch @catch in Catches)
            {
                context.Varibles[@catch.Varible.Id] = exception;
                @catch.Body.Execute(context);
            }
        }
        return null;
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