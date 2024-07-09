

namespace Cppia.NET.Instructions;

public class GetThisFieldInstruction : BaseFieldInstruction
{
    public GetThisFieldInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader, false){}
}
