﻿using System.Reflection;
using CleanArc_Kevin.Core.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace CleanArc_Kevin.Endpoints.API.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, params string[] assemblyNamesForSearch)
    {
        var assemblies = GetAssemblies(assemblyNamesForSearch);
        services.AddApplicationServices(assemblies)
            .AddDataAccess(assemblies)
            .AddUtilityServices()
            .AddCostumeDependencies(assemblies);
        return services;
    }

    public static IServiceCollection AddCostumeDependencies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        => services.AddWithTransientLifetime(assemblies, typeof(ITransientLifetime))
            .AddWithScopedLifetime(assemblies, typeof(IScopeLifetime))
            .AddWithSingletonLifetime(assemblies, typeof(ISingletonLifetime));

    public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }

    public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }

    public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        return services;
    }


    private static List<Assembly> GetAssemblies(string[] assemblyName)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default?.RuntimeLibraries;
        if (dependencies == null)
            return assemblies;
        foreach (var library in dependencies)
        {
            if (!IsCandidateCompilationLibrary(library, assemblyName))
                continue;
            var assembly = Assembly.Load(new AssemblyName(library.Name));
            assemblies.Add(assembly);
        }

        return assemblies;
    }

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
        => assemblyName.Any(compilationLibrary.Name.Contains) || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
}