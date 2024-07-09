using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Cppia.NET;

public class Context
{
    public Context(CppiaCompiller compiller, ModuleDefinition moduleDefinition)
    {
        Compiller = compiller;
        Module = moduleDefinition;
    }

    public CppiaCompiller Compiller { get; }
    public ModuleDefinition Module { get; }
    
    public List<int> VariblesMap { get; } = new();
    public Dictionary<int, TypeReference> VaribleTypes { get; } = new();

    public TypeReference? ResolveType(string type)
    {
        return Compiller.ResolveType(type, Module);
    }

    public TypeDefinition ResolveTypeDeifinition(TypeReference reference)
    {
        if (reference is TypeDefinition type)
        {
            Module.ImportReference(type);
            return type;
        }
        return reference.Resolve();
    }

    public TypeDefinition? ResolveTypeDeifinition(string typeName)
    {
        var reference = ResolveType(typeName);
        if (reference is TypeDefinition type)
        {
            Module.ImportReference(type);
            return type;
        }
        return reference?.Resolve();
    }

    public MethodReference? ResolveMethod(string type, string method)
    {
        return Compiller.ResolveMethod(type, method, Module);
    }
}
