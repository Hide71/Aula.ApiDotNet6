using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotnet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aula.ApiDotNet6.Application.Mappings;
using Aula.ApiDotnet6.Infra.Data.Context;
using Aula.ApiDotNet6.Application.Services;
using Aula.ApiDotNet6.Application.Services.Interfaces;

namespace Aula.ApiDotNet6.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }

    }
}
