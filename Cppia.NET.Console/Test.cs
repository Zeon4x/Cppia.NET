using Cppia;
//using Cppia.NET.IL;
using Cppia.Runtime;

public class Test
{
    public void Invoke(CppiaRuntime runtime, object[] args)
    {
       // ((IMethod)runtime.GetClass("SomeClass").GetVarible("SomeVarible").GetValue(null)).Invoke(null, "12", new PosInfo("File", 1,"Class","method"));
    }
}