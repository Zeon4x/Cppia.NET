using System.Collections;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class ArrayIInstruction : CppiaInstruction, IAssignable
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

    private (IList, int) Unwrap(Context context) 
    {
        if(ThisInstruction.Execute(context) is not IList list)
            throw new NullReferenceException("Array object cannot be null");
        if(InputInstruction.Execute(context) is not int index)
            throw new NullReferenceException("Element index cannot be null");
        return (list, index);
    }

    public override object? Execute(Context context)
    {
        var (list, index) = Unwrap(context);
        return list[index];
    }

    public void Assign(Context context, Func<object?, object?> assignFunction)
    {
        var (list, index) = Unwrap(context);
        list[index] = assignFunction(list[index]);
    }
}