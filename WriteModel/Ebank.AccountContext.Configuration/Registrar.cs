using Framework.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Ebank.AccountContext.Configuration
{
    public class Registrar : RegistrarBase<Registrar>, IRegistrar
    {
        public override void Register(IServiceCollection services)
        {
            base.Register(services);
        }
    }
}