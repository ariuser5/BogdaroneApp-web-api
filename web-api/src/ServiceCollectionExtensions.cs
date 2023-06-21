using BogdaroneApp.Domain.DataAccess;
using BogdaroneApp.QuickData;

public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddRepository<TEntity, TRepository>(this IServiceCollection services)
        where TEntity : class
        where TRepository : class, IRepository<TEntity>, IScopedRepository, new()
    {
        services.AddScoped<IRepository<TEntity>, TRepository>(serviceProvider => {
            TRepository implementation = new();
            implementation.DbContext = serviceProvider.GetRequiredService<IDbContext>();
            return implementation;
        });

        return services;
    }
}