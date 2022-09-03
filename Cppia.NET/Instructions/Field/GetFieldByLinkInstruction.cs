using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class GetFieldByLinkInstruction : BaseFieldInstruction, IAssignable
{

    public GetFieldByLinkInstruction(CppiaFile file, CppiaReader reader, bool thisObject)
        :base(file, reader, !thisObject) {}

    public override object? Execute(Context context)
    {
        if (context.Runtime.GetClass(Class) is not IClass @class)
            throw new NullReferenceException("Class not found: "+Class);

        object? obj = context.This;
        if(Object is not null)
            obj = Object.Execute(context);

        if(obj is null)
            throw new NullReferenceException("Cannot get field value of null");
        
        if (@class.GetVarible(Field) is IVarible property)
            return property.GetValue(obj);
        if (@class.GetMethod(Field) is IMethod method)
            return method;

        throw new Exception($"Field {Field} not found in class "+Class);
    }

    public override void Assign(Context context, Func<object?, object?> assignFunction)
    {
        object? obj;
        if(Object is null)
            obj = context.This;
        else
            obj = Object?.Execute(context);
        
        if(obj is null)
            throw new Exception("Cannot assign field of null");

        Assign(context, assignFunction, obj);
    }
}