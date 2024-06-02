using System.Data.SqlClient;
using CleanArc_Kevin.Endpoints.API.Filters;
using CleanArc_Kevin.Endpoints.API.MiddleWares.ApiExceptionHandler;
using FluentValidation.AspNetCore;

namespace CleanArc_Kevin.Endpoints.API.Extensions.DependencyInjection;

public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(TrackActionPerformanceFilter));
        }).AddFluentValidation();
        services.AddDependencies(assemblyNamesForLoad);
        return services;
    }


    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseApiExceptionHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == nameof(SqlException))
                    error.Detail = "Exception was a database exception!";
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                    return LogLevel.Critical;
                return LogLevel.Error;
            };
        });
    }
}