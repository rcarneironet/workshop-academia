using Academia.Store.Infrastructure.IoC.Application;
using Academia.Store.Infrastructure.IoC.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Academia.Store.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            //Servicos de App
            new ApplicationBootstrapper().ChildServiceRegister(services);
            //Servicos de Domain
            //Servicos de Repositorio
            new RepositoryBootstrapper().ChildServiceRegister(services);
            //Infra
        }
    }
}
