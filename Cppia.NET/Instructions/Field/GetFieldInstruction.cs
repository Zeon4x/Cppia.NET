using System.Collections;
using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class GetFieldInstruction : BaseFieldInstruction, IAssignable
{
    public CppiaInstruction Object { get; }

    public GetFieldInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) => Object = ReadInstruction(file, reader);

    //private const BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    public override object? Execute(Context context)
    {
        if (Object.Execute(context) is not IDictionary obj)
            throw new Exception("Expected object");
        return obj[Field];
    }

    public override void Assign(Context context, Func<object?, object?> assignFunction)
    {
        var obj = Object.Execute(context);
        if (obj is IDictionary dictionary)
        {
            object? value = null;
            if (dictionary.Contains(Field))
                value = dictionary[Field];
            
            dictionary[Field] = assignFunction(value);
        }
        else
            throw new NotImplementedException();
    }
}