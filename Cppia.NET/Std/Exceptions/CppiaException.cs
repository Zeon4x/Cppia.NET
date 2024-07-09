using Cppia.Runtime;

namespace Cppia.Std.Exceptions;

public class CppiaException : Exception
{
    public CppiaException(string? message) : base(message){}

    public static CppiaException? Thrown(object? exception)
    {
        if(exception is string message)
            return new ValueException(message);
        if(exception is CppiaInstance cppiaInstance)
            exception = cppiaInstance.NativeSuper;
        return exception as CppiaException;
    }

    public static CppiaException Caught(object? exception)
    {
        if(exception is CppiaException cppiaException)
            return cppiaException;
        if(exception is Exception nativeException)
            return new ValueException(nativeException.Message);
        throw new Exception("Caught unknow exception type");
    }
}