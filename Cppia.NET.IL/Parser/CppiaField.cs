namespace Cppia;

public class CppiaMember
{
    public bool IsStatic { get; }
    protected CppiaFile File { get; }

    public CppiaMember(CppiaFile file, CppiaReader reader)
    {
        File = file;
        IsStatic = reader.ReadBoolean();
    } 
}