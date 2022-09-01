

using Cppia.Runtime;

namespace Cppia.Instructions;

public class TVarsInstruction : CppiaInstruction
{
    public List<VaribleDeclaration> Varibles { get; } = new();
    public TVarsInstruction(CppiaFile file, CppiaReader reader)
    {
        byte count = reader.ReadByte();
        for (int i = 0; i < count; i++)
        {
            var code = (CppiaOpCode)reader.ReadByte();
            bool init = code == CppiaOpCode.IaVarDeclI;
            Varibles.Add(new VaribleDeclaration(file, reader,init));
        }
    }

    public override object? Execute(Context context)
    {
        foreach (var varible in Varibles)
            context.Varibles.Add(varible.Varible.Id, varible.Init?.Execute(context));
        return null;
    }
}