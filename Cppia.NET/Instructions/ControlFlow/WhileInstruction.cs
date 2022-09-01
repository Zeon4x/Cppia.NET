using Cppia.Runtime;

namespace Cppia.Instructions;

public class WhileInstruction : CppiaInstruction
{
    public bool IsWhileDo { get; }
    public CppiaInstruction Condition { get; }
    public CppiaInstruction LoopBody { get; }

    public WhileInstruction(CppiaFile file, CppiaReader reader)
    {
        IsWhileDo = reader.ReadBoolean();
        Condition = ReadInstruction(file, reader);
        LoopBody = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {

        if (IsWhileDo)
        {
            while ((bool)Condition.Execute(context)!)
            {
                var value = LoopBody.Execute(context);
                if (value is ReturnResult result)
                    return result;
                if (value is BreakInstruction)
                    return null;
                if (value is ContinueInstruction)
                    continue;
            }

        }
        else
        {
            do
            {
                var value = LoopBody.Execute(context);

                if (value is ReturnResult result)
                    return result;
                if (value is BreakInstruction)
                    return null;
                if (value is ContinueInstruction)
                    continue;
            }
            while ((bool)Condition.Execute(context)!);
        }
        return null;
    }
}