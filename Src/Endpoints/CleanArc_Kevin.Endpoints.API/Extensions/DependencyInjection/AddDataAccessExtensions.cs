using System.Reflection;
using CleanArc_Kevin.Core.Contracts.Data.Commands;
using CleanArc_Kevin.Core.Contracts.Data.Queries;

namespace CleanArc_Kevin.Endpoints.API.Extensions.DependencyInjection;

public static class AddDataAccessExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddRepositories(assembliesForSearch).AddUnitOfWorks(assembliesForSearch);

    public static IServiceCollection AddRepositories(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<>), typeof(IQueryRepository));

    public static IServiceCollection AddUnitOfWorks(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));
}