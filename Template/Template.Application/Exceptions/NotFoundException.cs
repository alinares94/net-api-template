using System.Text.Json;

namespace $safeprojectname$.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message) : this(message, Constantes.Errors.NOT_FOUND_DEFAULT_ERROR)
    {
    }

    public NotFoundException(string message, string exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }

    public string ExceptionCode { get; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(new { ExceptionCode, Message, StackTrace });
    }
}
