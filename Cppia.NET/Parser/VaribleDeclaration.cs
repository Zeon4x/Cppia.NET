namespace Cppia.Instructions;

public class VaribleDeclaration : CppiaInstruction
{
    public CppiaLocalVarible Varible { get; }
    public CppiaInstruction? Init { get; }

    public VaribleDeclaration(CppiaFile file, CppiaReader reader, bool initialize)
    {
        Varible = new CppiaLocalVarible(file, reader);
        if (initialize)
        {
            int type = reader.ReadInt();
            Init = ReadInstruction(file, reader);
        }
    }
}