using FluentValidation.Results;
using System.Text.Json;

namespace $safeprojectname$.Exceptions;
public class ValidationException : Exception
{
    public ValidationException() : base("Se presentaron uno o más errores de validación")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage).ToDictionary(x => x.Key, x => x.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(Errors);
    }
}
