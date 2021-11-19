using BankMilleniumRekrutacja.Module.Foo.Domain;
using BankMilleniumRekrutacja.Shared.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BankMilleniumRekrutacja
{
    public static class ConfigurationExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<Repository<Foo>, InMemoryFooRepository>();
        }
    }
}
