using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$;
public static class DIExtensions
{

    public static IServiceCollection AddInfrastructureDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TemplateContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
