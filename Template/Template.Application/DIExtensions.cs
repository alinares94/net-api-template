using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Mapper;

namespace $safeprojectname$;
public static class DIExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(x => x.FromCallingAssembly()
            .AddClasses(c => c.AssignableTo<IBaseService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddAutoMapper(typeof(MapperProfile));
        services.AddValidatorsFromAssemblyContaining<StatusValidator>();

        return services;
    }
}