using Cppia.Runtime;

namespace Cppia.Instructions;

public class GetThisFieldInstruction : BaseFieldInstruction, IAssignable
{
    public GetThisFieldInstruction(CppiaFile file, CppiaReader reader) 
        : base(file, reader){}

    public override void Assign(Context context, Func<object?, object?> assignFunction) 
        => Assign(context, assignFunction, context.This);
}
