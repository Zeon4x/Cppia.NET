

using Cppia.Runtime;

namespace Cppia.Instructions;

public class ObjectDefInstruction : CppiaInstruction
{
    public List<string> Fields { get; } = new();
    public List<CppiaInstruction> Values { get; } = new();

    public ObjectDefInstruction(CppiaFile file, CppiaReader reader)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
            Fields.Add(file.Strings[reader.ReadInt()]);
        ReadInstructions(Values, file, reader, count);
    }

    public override object? Execute(Context context)
    {
        var obj = new Dictionary<string, object?>();
        for (int i = 0; i < Values.Count; i++)
            obj[Fields[i]] = Values[i].Execute(context);
        return obj;
    }
}