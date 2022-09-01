using Cppia.Runtime;

namespace Cppia.Instructions;

public class SwitchInstruction : CppiaInstruction
{
    public CppiaInstruction Condition { get; }
    public List<CppiaCase> Cases { get; } = new();
    public CppiaInstruction? DefaultCase { get; }

    public SwitchInstruction(CppiaFile file, CppiaReader reader) 
    {
        var casesCount = reader.ReadInt();
        bool hasDefault = reader.ReadBoolean();
        Condition = ReadInstruction(file, reader);
        for (int i = 0; i < casesCount; i++)
            Cases.Add( new CppiaCase(file, reader) );
        if(hasDefault)
            DefaultCase = ReadInstruction(file, reader);
    }

    public override object? Execute(Context context)
    {
        var switchCondition = Convert.ToInt32(Condition?.Execute(context));
        foreach (var @case in Cases)
        {
            foreach (var conditionInstruction in @case.Conditions)
            {
                var condition = Convert.ToInt32(conditionInstruction.Execute(context));
                if (switchCondition == condition)
                    return @case.Body.Execute(context);
            }
        }

        return DefaultCase?.Execute(context);
    }

    public class CppiaCase
    {
        public List<CppiaInstruction> Conditions { get; } = new();
        public CppiaInstruction Body { get; }

        public CppiaCase(CppiaFile file, CppiaReader reader)
        {
            ReadInstructions(Conditions, file, reader, reader.ReadInt());
            Body = ReadInstruction(file, reader);
        }
    }
}