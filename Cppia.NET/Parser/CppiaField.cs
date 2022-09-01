namespace Cppia;

public class CppiaField
{
    public bool IsStatic { get; }
    protected CppiaFile File { get; }

    public CppiaField(CppiaFile file, CppiaReader reader)
    {
        File = file;
        IsStatic = reader.ReadBoolean();
    } 
}