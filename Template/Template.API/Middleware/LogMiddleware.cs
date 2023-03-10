namespace $safeprojectname$.Middleware;

/// <summary>
/// Middleware encargado de insertar un Log con las entradas/salidas de la API
/// </summary>
public class LogMiddleware : IMiddleware
{
    private readonly ILogger<LogMiddleware> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    public LogMiddleware(ILogger<LogMiddleware> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Establece propiedades adicionales y registra un log de todas las peticiones
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        LogStart(context);
        await next(context);
        LogEnd(context);
    }

    private void LogEnd(HttpContext context)
    {
        string url = context.Request.Path.ToUriComponent();
        _logger.LogInformation("End Request. {url}", url);
    }

    private void LogStart(HttpContext context)
    {
        string url = context.Request.Path.ToUriComponent();
        if (url.Contains("swagger"))
            return;

        _logger.LogInformation("Start Request. {url}", url);
    }
}

