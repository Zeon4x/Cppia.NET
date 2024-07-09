namespace Cppia;

public class CppiaClass : CppiaType
{

    public CppiaClass(CppiaFile file, CppiaReader reader) 
        : base(file, reader, true)
    {
        ReadInterfaces(file, reader);
        ReadFields(file, reader,true);
    }

    public CppiaField[] GetVaribles()
    {
        return Members.OfType<CppiaField>().ToArray();
    }

    public CppiaMethod[] GetMethods()
    {
        return Members.OfType<CppiaMethod>().ToArray();
    }
}