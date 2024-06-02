using CleanArc_Kevin.Core.Abstractions.Logger;
using CleanArc_Kevin.Utilities;

namespace CleanArc_Kevin.Endpoints.API.Extensions.DependencyInjection;

public static class AddServiceExtensions
{
    public static IServiceCollection AddUtilityServices(this IServiceCollection services)
    {
        services.AddScoped<IScopeInformation, ScopeInformation>();
        services.AddTransient<CommonService>();
        return services;
    }
}