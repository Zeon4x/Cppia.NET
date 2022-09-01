using System;
using HVM.Tests.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HVM;
using Cppia.Runtime;

namespace HVM.Tests;

[TestClass]
public class NativeCallTests
{
    private IClass _class;

    private readonly TestClass _testClass = new TestClass();

    [TestInitialize]
    public void Setup()
    {
        var runtime = CppiaTest.LoadRuntime();
        _class = runtime.GetClass("NativeCallTests");
    }

    [TestMethod]
    public void Call_Static_Method() => _class.GetMethod("callStaticMethod").Invoke(null);
    
    [TestMethod]
    public void Call_Static_Method_Get_Return()
    {
        var result = _class.GetMethod("callStaticMethodWithReturn").Invoke(null, 1);
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Construct_Native()
    {
        var result = _class.GetMethod("construct").Invoke(null);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Construct_Width_Params()
    {
        object instance = _class.GetMethod("constructWithParams").Invoke(null, 2);
        TestClass2 testClass = (TestClass2)instance;
        Assert.AreEqual(2,testClass.Number);
    }

    [TestMethod]
    public void Call_Method() => _class.GetMethod("callMethod").Invoke(null, _testClass);
    
    [TestMethod]
    public void Call_Method_And_With_Return() 
    {
        var result = _class.GetMethod("callMethodAndWithReturn").Invoke(null,_testClass,3);
        Assert.AreEqual(3,result);
    }

    [TestMethod]
    public void Get_Static_Property()
    {
        var value = _class.GetMethod("getStaticProperty").Invoke(null);
        Assert.AreEqual(TestClass.TestStaticProperty,value);
    }

    [TestMethod]
    public void Get_Property()
    {
        var testClass = new TestClass();
        var value = _class.GetMethod("getProperty").Invoke(null,testClass);
        Assert.AreEqual(testClass.TestProperty,value);
    }

    [TestMethod]
    public void Set_Static_Property()
    {
        _class.GetMethod("setStaticProperty").Invoke(null,2);
        Assert.AreEqual(2, TestClass.TestStaticProperty);
    }

    [TestMethod]
    public void Set_Property()
    {
        _class.GetMethod("setProperty").Invoke(null,_testClass,2);
        var testClass = (TestClass)_testClass;
        Assert.AreEqual(2, testClass.TestProperty);
    }
}
