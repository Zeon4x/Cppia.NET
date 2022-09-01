using System.Collections;
using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class BaseAssignInstruction : CppiaInstruction
{
    public CppiaInstruction Object { get; }
    public CppiaInstruction Value { get; }

    public BaseAssignInstruction(CppiaFile file, CppiaReader reader)
    {
        Object = ReadInstruction(file, reader);
        Value = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        var newValue = Value.Execute(context);
        if (Object is IAssignable assignable)
            assignable.Assign(context, value => Assign(value, newValue));
        else
            throw new NotImplementedException();
        return null;
    }

    protected virtual object? Assign(object? currentValue, object? value)
    {
        var left = Convert.ToDouble(currentValue);
        var right = Convert.ToDouble(value);
        return Assign(left, right);
    }

    protected virtual double Assign(double currentValue, double value) => throw new NotImplementedException();
}
