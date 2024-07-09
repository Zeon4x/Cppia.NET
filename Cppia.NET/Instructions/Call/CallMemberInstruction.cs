using System.Reflection;
using Cppia.Runtime;

namespace Cppia.Instructions;

public class CallMemberInstruction : BaseCallInstruction
{
    public string ClassName { get; }
    public string FieldName { get; }
    public CppiaInstruction ThisInstruction { get; }

    public CallMemberInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        FieldName = file.Strings[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ThisInstruction = ReadInstruction(file, reader);
        ReadArguments(file, reader, argsCount);
    }

    public override object? Execute(Context context)
    {
        if (context.Runtime.GetClass(ClassName) is not IClass @class)
            throw new Exception("Class not found: " + ClassName);
        if (@class.GetMethod(FieldName) is not IMethod method)
            throw new Exception($"Method {FieldName} not found in class {ClassName} .");
            
        object? obj = ThisInstruction.Execute(context);
        return method.Invoke(obj, GetArguments(context));
    }


}