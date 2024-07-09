namespace Cppia;

public class CppiaParameter
{
    public string Name { get; }
    public bool Optional { get; }
    public string Type { get; }

    public CppiaParameter(CppiaFile file, CppiaReader reader)
    {
        var nameId = reader.ReadInt();
        Name = file.Strings[nameId];
        Optional = reader.ReadBoolean();
        Type = file.Types[reader.ReadInt()];
    }
}