namespace Cppia;

public struct CppiaEnumConstructor
{
    public string Name { get; }
    public List<Argument> Arguments { get; } = new();

    public CppiaEnumConstructor(CppiaFile file, CppiaReader reader)
    {
        var nameIndex = reader.ReadInt();
        Name = file.Strings[nameIndex];
        int argCount = reader.ReadInt();
        for (int i = 0; i < argCount; i++)
            Arguments.Add(new Argument(file, reader));
    }

    public struct Argument
    {
        public string Name { get; }
        public string Type { get; }

        public Argument(CppiaFile file, CppiaReader reader)
        {
            Name = file.Strings[reader.ReadInt()];
            Type = file.Types[reader.ReadInt()];
        }
    }
}