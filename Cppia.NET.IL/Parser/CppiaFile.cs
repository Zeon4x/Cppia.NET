using Cppia.NET.Instructions;
namespace Cppia;

public class CppiaFile
{
    private readonly CppiaReader _reader;
    public List<string> Strings { get; } = new();
    public List<string> Types { get; } = new();

    public List<CppiaType> CppiaTypes { get; } = new();

    public CppiaInstruction? Main { get; }

    public CppiaFile(string path)
        :this(File.OpenRead(path)) {}

    public CppiaFile(byte[] bytes) 
        : this(new MemoryStream(bytes)) {}

    public CppiaFile(Stream stream)
    {
        _reader = new CppiaReader(stream);
        var first = new string(_reader.ReadChars(5));
        if (first != "CPPIB")
            throw new InvalidDataException("Invalid file");
        PopulateList(Strings, _reader.ReadAnsiiString, _reader.ReadAnsiInt());
        PopulateList(Types, _reader.ReadAnsiiString, _reader.ReadAnsiInt());
        var classCount = _reader.ReadAnsiInt();
        _reader.ReadByte();
        PopulateList(CppiaTypes, ReadType, classCount);
        Main = ReadMain();
        _reader.Close();
    }

    private CppiaInstruction? ReadMain()
    {
        var code = (CppiaOpCode)_reader.ReadByte();
        if(code == CppiaOpCode.IaMain)
            return CppiaInstruction.ReadInstruction(this, _reader);
        return null;
    }

    private static void PopulateList<T>(List<T> list, Func<T> every, int count)
    {
        for (int i = 0; i < count; i++)
            list.Add(every());
    }

    private CppiaType ReadType()
    {
        CppiaOpCode code = (CppiaOpCode)_reader.ReadByte();
        return code switch
        {
            CppiaOpCode.IaClass => new CppiaClass(this, _reader),
            CppiaOpCode.IaInterface => new CppiaInterface(this, _reader),
            CppiaOpCode.IaEnum => new CppiaEnum(this, _reader),
            _ => throw new NotImplementedException()
        };
    }

}