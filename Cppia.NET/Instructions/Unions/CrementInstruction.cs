

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
        double value = Convert.ToDouble(Value.Execute(context));
        var result = Execute(ref value);

        if (Value is VaribleInstruction varInstruction)
            context.Varibles[varInstruction.VaribleId] = value;
        else if(Value is BaseFieldInstruction instruction)
            instruction.Assign(context, v => value);
        else
            throw new NotImplementedException();
        return result;

    }

    protected abstract double Execute(ref double value);
}