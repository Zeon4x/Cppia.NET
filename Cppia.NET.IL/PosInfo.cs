namespace Cppia.NET;

public record PosInfo
{

    public PosInfo(string file, int line, string @class, string method)
    {
        this.File = file;
        this.Line = line;
        this.Class = @class;
        this.Method = method;
    }

    public string File { get; }
    public int Line { get; }
    public string Class { get; }
    public string Method { get; }

    
}