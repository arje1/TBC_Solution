using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonRegister.Core.Application.Interfaces;

namespace PersonRegister.Infrastructure.Database
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfPersonRegister, UnitOfPersonRegister>();
            services.AddDbContext<PersonRegister_DbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PersonRegisterDbConnection")));
        }

       
    }
}
