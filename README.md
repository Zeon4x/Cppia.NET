# Cppia.NET
Cppia interpreter for .NET. 
Intended for embedding into applications or games. 

## How to use
```cs
var runtime = new CppiaRuntime();
// Expose type from .NET
runtime.RegisterType(typeof(Console));

runtime.Load("path/to/file.cppia");
var method = runtime.GetClass("MyClass").GetMethod("MyMethod");
method.Invoke(null);
```
## Implemented
- [x] Classes
- [x] Enums
- [x] Objects
- [x] Array/Map
- [ ] Dynamic varibles
- [ ] Std library