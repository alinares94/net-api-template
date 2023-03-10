using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;
using $safeprojectname$.Responses;
using $ext_safeprojectname$.Application.Exceptions;

namespace $safeprojectname$.Filters;

public class ExceptionFilter : IActionFilter
{

    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
            return;

        switch (context.Exception)
        {
            case InternalServerException internalException:
                _logger.LogInformation("Custom Exception ExceptionFilter");
                ProcessError(context, internalException, internalException.ExceptionCode, (int)HttpStatusCode.InternalServerError);
                break;
            case ValidationException validationException:
                _logger.LogInformation("Validation Exception ExceptionFilter");
                ProcessError(context, validationException, "-", (int)HttpStatusCode.InternalServerError);
                break;
            case NotFoundException notFoundException:
                _logger.LogInformation("Not Found Exception ExceptionFilter");
                ProcessError(context, notFoundException, notFoundException.ExceptionCode, (int)HttpStatusCode.NotFound);
                break;
            default:
                _logger.LogInformation("Exception ExceptionFilter");
                ProcessError(context, context.Exception, "-", (int)HttpStatusCode.InternalServerError);
                break;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    { }

    private void ProcessError(ActionExecutedContext context, Exception ex, string internalCode, int statusCode)
    {
        _logger.LogError(ex, ex.Message);

        var response = new ApiResponse<object>
        {
            Data = null,
            Error = new ApiError { Code = internalCode, Message = ex.ToString() },
        };
        context.Result = new ContentResult
        {
            StatusCode = statusCode,
            Content = JsonSerializer.Serialize(response),
            ContentType = "application/json"
        };
        context.ExceptionHandled = true;
    }
}
