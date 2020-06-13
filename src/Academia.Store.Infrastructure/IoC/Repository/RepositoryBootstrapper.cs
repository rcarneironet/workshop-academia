using Academia.Store.Application.Repositories.Dapper;
using Academia.Store.Infrastructure.DataAccess.Dapper.Context;
using Academia.Store.Infrastructure.DataAccess.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Academia.Store.Infrastructure.IoC.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<DapperContext, DapperContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
