

using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class CrementInstruction : CppiaInstruction
{
    public CppiaInstruction Value { get; }
    public CrementInstruction(CppiaFile file, CppiaReader reader)
    {
        Value = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        if (Value is VaribleInstruction instruction)
        {
            double value = Convert.ToDouble(Value.Execute(context));
            var result = Execute(ref value);
            context.Varibles[instruction.VaribleId] = value;
            return result;
        }
        throw new NotImplementedException();
    }

    protected abstract double Execute(ref double value);
}