using Cppia;
using HVM.Tests.Native;

namespace HVM.Tests;

public class CppiaTest
{
    public static CppiaRuntime LoadRuntime()
    {
        var runtime = new CppiaRuntime();
        runtime.RegisterType(typeof(TestClass));
        runtime.RegisterType(typeof(TestClass2));
        runtime.Load("../../../HaxeProject/bin/HaxeProject.cppia");
        return runtime;
    }
}