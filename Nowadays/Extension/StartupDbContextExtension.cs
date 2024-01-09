using Microsoft.EntityFrameworkCore;
using Nowadays.DAL.Context;

namespace ExampleApi.Extension
{
    public static class StartupDbContextExtension
    {
        public static IServiceCollection AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbtype = configuration.GetConnectionString("DbType");

            if(dbtype == "SQL")
            {
                services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sqlServerOptions => sqlServerOptions.CommandTimeout(120));

                    });
            }
            return services;
        }
    }
}
