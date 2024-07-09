using System.Reflection;
using Cppia.NET;

CppiaCompiller compiller = new();
compiller.AddReference(Assembly.GetExecutingAssembly());
compiller.CompileToFile("test", new Cppia.CppiaFile("TestProject/bin/test.cppia"));
var assembly = Assembly.LoadFrom("Test.dll");
Console.WriteLine(assembly.GetType("Main")?.GetMethod("main")?.Invoke(null, null));