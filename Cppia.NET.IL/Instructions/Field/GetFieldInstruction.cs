using System.Collections;
using System.Reflection;


namespace Cppia.NET.Instructions;

public class GetFieldInstruction : BaseFieldInstruction
{

    public GetFieldInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader, true) {}

    //private const BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    
}