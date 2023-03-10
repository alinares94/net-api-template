using System.Text.Json;

namespace $safeprojectname$.Exceptions;
public class InternalServerException : Exception
{
    public InternalServerException(string message) : this(message, Constantes.Errors.INTERNAL_DEFAULT_ERROR)
    {
    }

    public InternalServerException(string message, string exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }

    public string ExceptionCode { get; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(new { ExceptionCode, Message, StackTrace });
    }
}
