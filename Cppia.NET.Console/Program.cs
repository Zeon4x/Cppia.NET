using System.Diagnostics;
using Cppia;
using Cppia.Runtime;

var runtime = new CppiaRuntime();
runtime.RegisterType(typeof(Log), "haxe.Log");
runtime.RegisterGlobal("__time_stamp", () => (double)DateTime.Now.Ticks/TimeSpan.TicksPerSecond);
runtime.Load("TestProject/bin/test.cppia")?.Execute(new Context(runtime));