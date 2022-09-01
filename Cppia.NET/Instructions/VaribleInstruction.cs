

using Cppia.Runtime;

namespace Cppia.Instructions;

public class VaribleInstruction : CppiaInstruction, IAssignable
{
    public int VaribleId { get; }
    
    public VaribleInstruction(CppiaFile file, CppiaReader reader)
    {
        VaribleId = reader.ReadInt();
    }

    public override object? Execute(Context context)
    {
        return context.Varibles[VaribleId];
    }

    public void Assign(Context context, Func<object?, object?> assignFunction)
    {
        object? currentValue = context.Varibles[VaribleId];
        context.Varibles[VaribleId] = assignFunction(currentValue);
    }
}