using System.Reflection;
using System.Security.Cryptography.X509Certificates;


namespace Cppia.NET.Instructions;

public class GetFieldByLinkInstruction : BaseFieldInstruction
{

    public GetFieldByLinkInstruction(CppiaFile file, CppiaReader reader, bool thisObject)
        :base(file, reader, !thisObject) {}

    
}