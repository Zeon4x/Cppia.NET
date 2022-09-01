using System;
using Cppia.Runtime;
using HVM.Tests.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HVM.Tests;

[TestClass]
public class NativeBaseCallTests
{
    private IClass _class;

    [TestInitialize]
    public void Setup()
    {
        var runtime = CppiaTest.LoadRuntime();
        _class = runtime.GetClass("NativeSuperCallTests");
    }

    [TestMethod]
    public void Construct()
    {
        var instance = (CppiaInstance)_class.GetMethod("construct").Invoke(null);
        Assert.IsNotNull(instance.NativeSuper);
    }

    [TestMethod]
    public void Construct_Width_Params()
    {
        var obj = (CppiaInstance)_class.GetMethod("constructWithParams").Invoke(null,1);
        var testClass = (TestClass2)obj.NativeSuper;
        Assert.AreEqual(1, testClass.Number);
    }

    [TestMethod]
    public void Call_Method() => _class.GetMethod("callMethod").Invoke(null);

    [TestMethod]
    public void Call_Base_Method() => _class.GetMethod("callSuperMethod").Invoke(null);
}
