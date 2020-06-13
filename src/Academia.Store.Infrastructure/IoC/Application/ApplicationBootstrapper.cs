using Academia.Store.Application.Handlers.CustomerHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Academia.Store.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
        }
    }
}
