using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StrideGo.Business.Common.Interfaces;

namespace StrideGo.Storage
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDatabaseContext, DatabaseContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            
            return services;
        }
    }
}
