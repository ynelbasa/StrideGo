using System;
using Microsoft.Extensions.DependencyInjection;

namespace StrideGo.Business
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services) {
            return services;
        }
    }
}
