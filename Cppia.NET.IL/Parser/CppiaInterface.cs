namespace Cppia;

public class CppiaInterface : CppiaType
{
    public CppiaInterface(CppiaFile file, CppiaReader reader) 
        : base(file, reader, true)
    {
        ReadInterfaces(file, reader);
        ReadFields(file, reader, false);
    }

    
}