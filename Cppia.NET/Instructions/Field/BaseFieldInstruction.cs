using System.Collections;
using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public abstract class BaseFieldInstruction : CppiaInstruction, IAssignable
{
    public string Class { get; }
    public string Field { get; }

    public BaseFieldInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
    }

    public void Assign(Context context, Func<object?, object?> assignFunction, object? @obj)
    {
        if (context.Runtime.GetClass(Class) is not IClass @class)
            throw new Exception("Class not found: " + Class);

        if (@class.GetVarible(Field) is IVarible varible)
            varible.SetValue(@obj, assignFunction(varible.GetValue(@obj)));
        else
            throw new Exception($"Type {@class} has no declared field " + Field);
    }

    public abstract void Assign(Context context, Func<object?, object?> assignFunction);
}