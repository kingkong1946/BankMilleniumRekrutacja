using BankMilleniumRekrutacja.Module.Foo.Application;
using BankMilleniumRekrutacja.Module.Foo.Domain;
using BankMilleniumRekrutacja.Module.Foo.Infrastructure;
using BankMilleniumRekrutacja.Shared.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BankMilleniumRekrutacja
{
    public static class ConfigurationExtensions
    {
        public static void AddFooModule(this IServiceCollection services)
        {
            services.AddSingleton<FooService>();
            services.AddSingleton<Repository<FooAggregate>, InMemoryFooRepository>();
        }
    }
}
