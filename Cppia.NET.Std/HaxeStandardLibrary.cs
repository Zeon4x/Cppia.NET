using Cppia.NET.Std;

namespace Cppia.Std;

public static class HaxeStandardLibrary
{
    public static void LoadStandardLibrary(this CppiaRuntime runtime, bool importIO = true)
    {
        runtime.RegisterType<Date>();
        runtime.RegisterType<Reflect>();
        runtime.RegisterType<CppiaStd>("Std");
        runtime.RegisterType<CppiaType>("Type");
        runtime.RegisterType<StringBuffer>("StringBuf");
    }
}