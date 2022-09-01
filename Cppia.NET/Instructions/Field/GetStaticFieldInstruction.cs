using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class GetStaticFieldInstruction : BaseFieldInstruction, IAssignable
{
    public GetStaticFieldInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader) { }

    public override object? Execute(Context context)
    {
        if (context.Runtime.GetClass(Class) is not IClass @class)
            throw new NullReferenceException("Cannot get field value of null");

        if (@class.GetVarible(Field) is IVarible varible)
            return varible.GetValue(null);
        throw new Exception($"Field {Field} not found in class {Class}");
    }

    public override void Assign(Context context, Func<object?, object?> assignFunction) 
        => Assign(context, assignFunction, null);

}