using System.Data;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Cppia.NET;

public class CppiaCompiller
{
    private readonly Dictionary<string, Type> _types = new();
    private readonly Dictionary<string, TypeDefinition> _definedTypes = new();

    public CppiaCompiller()
    {
        _types.Add("void", typeof(void));
        _types.Add("int", typeof(int));
        _types.Add("String", typeof(string));
        _types.Add("Boolean", typeof(bool));
    }

    public void AddReference(System.Reflection.Assembly assembly)
    {
        foreach (var type in assembly.DefinedTypes)
        {
            object[] attributes = type.GetCustomAttributes(typeof(CppiaTypeAttribute), false);
            CppiaTypeAttribute? attribute = attributes.SingleOrDefault() as CppiaTypeAttribute;

            if(attribute is not null)
                _types.Add(attribute.Name ?? type.FullName!, type);
        }
    }

    public void CompileToFile(string name, CppiaFile file)
    {
        AssemblyDefinition assembly = Compile(name, file);
        var instructions = assembly.MainModule.Types[1].Methods[0].Body.Instructions;
        assembly.Write("Test.dll");
    }

    public void CompliteToStream(string name, CppiaFile file, Stream stream)
    {
        AssemblyDefinition assembly = Compile(name, file);
        assembly.Write(stream);
    }

    private AssemblyDefinition Compile(string name, CppiaFile file)
    {
        var assemblyName = new AssemblyNameDefinition(name, new Version());
        AssemblyDefinition assembly = AssemblyDefinition.CreateAssembly(assemblyName, name, ModuleKind.Dll);
        ModuleDefinition module = assembly.MainModule;
        foreach (var cppiaType in file.CppiaTypes)
        {
            TypeDefinition type = GenerateType(module, cppiaType);
            module.Types.Add(type);
        }
        GenerateMethodBodies(file.CppiaTypes, module);
        return assembly;
    }

    private static void SplitName(string fullName, out string type, out string @namespace)
    {
        int index = fullName.LastIndexOf('.');
        if (index > -1)
        {
            type = fullName[index..];
            @namespace = fullName[..index];
        }
        else
        {
            type = fullName;
            @namespace = string.Empty;
        }
    }

    private TypeDefinition GenerateType(ModuleDefinition module, CppiaType cppiaType)
    {
        SplitName(cppiaType.Name, out string typeName, out string @namespace);
        var type = new TypeDefinition(@namespace, typeName, TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.BeforeFieldInit | TypeAttributes.BeforeFieldInit);
        _definedTypes.Add(cppiaType.Name, type);

        if(string.IsNullOrEmpty(cppiaType.Super))
            type.BaseType = module.ImportReference(typeof(object));
        else
            type.BaseType = ResolveType(cppiaType.Name, module);

        foreach (var cppiaMethod in cppiaType.Methods)
        {
            if(cppiaMethod.Name.Equals("new"))
                type.Methods.Add(GenerateConstructor(module, cppiaMethod));
            else
                type.Methods.Add(GenerateMethod(module, cppiaMethod));
        }

        return type;
    }

    private MethodDefinition GenerateConstructor(ModuleDefinition module, CppiaMethod cppiaMethod)
    {
        const MethodAttributes ConstructorAttributes = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
        var method = new MethodDefinition(cppiaMethod.Name, ConstructorAttributes, ResolveType(cppiaMethod.ReturnType, module));
        return method;
    }

    private MethodDefinition GenerateMethod(ModuleDefinition module, CppiaMethod cppiaMethod)
    {
        var attributes = MethodAttributes.Public | MethodAttributes.HideBySig;
        if (cppiaMethod.IsStatic)
            attributes |= MethodAttributes.Static;

        var method = new MethodDefinition(cppiaMethod.Name, attributes, ResolveType(cppiaMethod.ReturnType, module));
        return method;
    }

    public TypeReference? ResolveType(string typeName, ModuleDefinition module)
    {
        if(_types.TryGetValue(typeName, out Type value))
            return module.ImportReference(value);
        if(_definedTypes.TryGetValue(typeName, out TypeDefinition type))
            return type;
        return null;
    }

    public MethodReference? ResolveMethod(string typeName, string methodName, ModuleDefinition module)
    {
        if(_types.TryGetValue(typeName, out Type type))
        {
            if(type.GetMethod(methodName) is System.Reflection.MethodInfo method)
                return module.ImportReference(method);
            return null;
        }
        if(_definedTypes.TryGetValue(typeName,out TypeDefinition definition))
        {
            return definition.GetMethods().Where(m => m.Name == methodName).SingleOrDefault();
        }
        return null;
    }

    private void GenerateMethodBodies(IEnumerable<CppiaType> types, ModuleDefinition module)
    {
        foreach (CppiaType type in types)
        {
            foreach (CppiaMethod cppiaMethod in type.Methods)
            {
                if(cppiaMethod.Body is null)
                    continue;
                var method = _definedTypes[type.Name].GetMethods()
                    .Single(m => m.Name == cppiaMethod.Name);
                
                ILProcessor processor = method.Body.GetILProcessor();
                cppiaMethod.Body.Emit(processor, new Context(this, module));
                method.Body.SimplifyMacros();
            }
        }
    }


}