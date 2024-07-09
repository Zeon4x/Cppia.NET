using Cppia;
using Cppia.Instructions;
using Cppia.Runtime;

var runtime = new CppiaRuntime();
runtime.RegisterType(typeof(Log), "haxe.Log");
runtime.RegisterGlobal("__time_stamp", () => (double)DateTime.Now.Ticks/TimeSpan.TicksPerSecond);
CppiaInstruction main = runtime.Load("TestProject/bin/test.cppia")!;
main.Execute(new Context(runtime));