namespace Cppia;

public class CppiaClass : CppiaType
{

    public CppiaClass(CppiaFile file, CppiaReader reader) 
        : base(file, reader, true)
    {
        ReadInterfaces(file, reader);
        ReadFields(file, reader,true);
    }

    public CppiaVarible[] GetVaribles()
    {
        return Fields.OfType<CppiaVarible>().ToArray();
    }

    public CppiaMethod[] GetMethods()
    {
        return Fields.OfType<CppiaMethod>().ToArray();
    }
}