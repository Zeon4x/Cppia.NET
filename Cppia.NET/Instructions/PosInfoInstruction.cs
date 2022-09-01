

using Cppia.Runtime;

namespace Cppia.Instructions;

public class PosInfoInstruction : CppiaInstruction
{
    public string File { get; }
    public int Line { get; }
    public string Class { get; }
    public string Method { get; }

    public PosInfoInstruction(CppiaFile file, CppiaReader reader)
    {
        File = file.Strings[reader.ReadInt()];
        Line = reader.ReadInt();
        Class = file.Strings[reader.ReadInt()];
        Method = file.Strings[reader.ReadInt()];
    }

    public override object? Execute(Context context) => this;
}