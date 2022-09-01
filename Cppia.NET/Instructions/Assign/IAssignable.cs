using Cppia.Runtime;

namespace Cppia.Instructions;

public interface IAssignable
{
    void Assign(Context context, Func<object?, object?> assignFunction);
}