namespace Cppia;

public class CppiaReader : BinaryReader
{
    public CppiaReader(Stream input) : base(input) { }

    public int ReadAnsiInt()
    {
        ReadByte(); // Skip whitespace
        int number = 0;
        char sym = ReadChar();
        while (char.IsDigit(sym))
        {
            number = number * 10 + int.Parse(sym.ToString());
            sym = ReadChar();
        }
        BaseStream.Position--;
        return number;
    }

    public string ReadAnsiiString()
    {
        var lenght = ReadAnsiInt();
        ReadByte(); // Skip whitespace
        if (lenght == 0)
            return string.Empty;
        return new string(ReadChars(lenght));
    }

    public int ReadInt()
    {
        int code = ReadByte();
        int result;
        if (code < 254)
            return code;
        if (code == 254)
        {
            result = ReadByte() | (ReadByte() << 8);
            return result;
        }

        result = ReadByte();
        result |= ReadByte() << 8;
        result |= ReadByte() << 16;
        result |= ReadByte() << 24;
        return result;
    }
}