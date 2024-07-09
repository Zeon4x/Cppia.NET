



using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class TVarsInstruction : CppiaInstruction
{
    public List<VaribleDeclaration> Varibles { get; } = new();
    public TVarsInstruction(CppiaFile file, CppiaReader reader)
    {
        byte count = reader.ReadByte();
        for (int i = 0; i < count; i++)
        {
            var code = (CppiaOpCode)reader.ReadByte();
            bool init = code == CppiaOpCode.IaVarDeclI;
            Varibles.Add(new VaribleDeclaration(file, reader,init));
        }
    }

    public override object? Emit(ILProcessor processor, Context context)
    {
       foreach(var declaration in Varibles)
        {
            context.VariblesMap.Add(declaration.Varible.Id);
            Mono.Cecil.TypeReference? variableType = context.ResolveType(declaration.Varible.Type) 
                ?? throw new Exception("Type not found");

            context.VaribleTypes.Add(declaration.Varible.Id, variableType);
            processor.Body.Variables.Add(new VariableDefinition(variableType));
            declaration.Emit(context.VariblesMap.Count-1, processor, context);
        }
        return null;
    }

    
}