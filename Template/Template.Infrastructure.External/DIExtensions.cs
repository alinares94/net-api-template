using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Application.Interfaces.External;
using $safeprojectname$.Services;

namespace $safeprojectname$;
public static class DIExtensions 
{

    public static IServiceCollection AddInfrastructureExternal(this IServiceCollection services) 
    {
        services.AddScoped<IExternalService, ExternalService>();

        return services;
    }
}
