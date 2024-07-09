namespace Cppia;

public class CppiaLocalVarible
{
    public string Name { get; }
    public int Id { get; }
    public bool Capture { get; }
    public string Type { get; }

    public CppiaLocalVarible(CppiaFile file, CppiaReader reader)
    {
        Name = file.Strings[reader.ReadInt()];
        Id = reader.ReadInt();
        Capture = reader.ReadBoolean();
        Type = file.Types[reader.ReadInt()];
    }
}