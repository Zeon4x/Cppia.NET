



using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public abstract class BinOperationInstruction : CppiaInstruction
{
    public CppiaInstruction Left { get; }
    public CppiaInstruction Right { get; }

    public BinOperationInstruction(CppiaFile file, CppiaReader reader)
    {
        Left = ReadInstruction(file, reader);
        Right = ReadInstruction(file, reader);
    }

    public virtual object Compute(double left, double right) => throw new NotImplementedException();

    public override object? Emit(ILProcessor processor, Context context)
    {
        Left.Emit(processor, context);
        Right.Emit(processor, context);
        Emit(processor);
        return context.ResolveType("int");
    }

    public virtual void Emit(ILProcessor processor) {}

}