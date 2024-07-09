using System.Collections;
using System.Reflection;


namespace Cppia.NET.Instructions;

public abstract class BaseAssignInstruction : CppiaInstruction
{
    public CppiaInstruction Object { get; }
    public CppiaInstruction Value { get; }

    public BaseAssignInstruction(CppiaFile file, CppiaReader reader)
    {
        Object = ReadInstruction(file, reader);
        Value = ReadInstruction(file, reader);
    }

    

    protected virtual double Assign(double currentValue, double value) => throw new NotImplementedException();
}
