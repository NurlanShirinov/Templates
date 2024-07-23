using DAL.Context;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Common;

namespace DAL;
public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, SqlUnitOfWork>((provider) =>
        {
            var dbContext = provider.GetRequiredService<AppDbContext>();
            return new SqlUnitOfWork(dbContext , connectionString!);
        });


        return services;
    }
}