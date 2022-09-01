using Cppia.Instructions;
namespace Cppia;

public class CppiaMethod : CppiaField
{
    public string Name { get; }
    public bool IsDynamic { get; }
    public string ReturnType { get; }
    public List<CppiaParameter> Parameters { get; } = new();

    public CppiaInstruction? Body { get; }


    public CppiaMethod(CppiaFile file, CppiaReader reader, bool hasBody)
        :base(file, reader)
    {
        IsDynamic = reader.ReadBoolean();
        Name = file.Strings[reader.ReadInt()];
        ReturnType = file.Types[reader.ReadInt()];
        
        int count = reader.ReadByte();
        for (int i = 0; i < count; i++)
            Parameters.Add(new CppiaParameter(file, reader));
        
        if(hasBody)
            Body = CppiaInstruction.ReadInstruction(file, reader);
    }
}