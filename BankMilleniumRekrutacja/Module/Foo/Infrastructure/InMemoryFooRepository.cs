namespace BankMilleniumRekrutacja.Module.Foo.Infrastructure
{
    using BankMilleniumRekrutacja.Shared.Infrastructure;
    using BankMilleniumRekrutacja.Module.Foo.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Microsoft.Extensions.Logging;

    public class InMemoryFooRepository : Repository<FooAggregate>
    {
        private readonly IList<FooAggregate> store = new List<FooAggregate>();
        private readonly ILogger logger;

        public InMemoryFooRepository(ILogger<InMemoryFooRepository> logger)
        {
            this.logger = logger;
        }

        public Task<FooAggregate> GetAsync(int id)
        {
            try
            {
                var foo = this.store.First(storedFoo => storedFoo.Id == id);
                return Task.FromResult(foo);
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("GetAsync - Foo is not found in repository");
                throw;
            }
        }

        public Task AddAsync(FooAggregate foo)
        {
            var model = this.store.FirstOrDefault(storedFoo => storedFoo.Id == foo.Id);

            if (model != null)
            {
                var message = "AddAsync - Foo is exist";
                this.logger.LogError(message);
                throw new InvalidOperationException(message);
            }

            foo.Id = this.store.Count > 0 ? this.store.Select(storedFoo => storedFoo.Id).Max() + 1 : 1;

            this.store.Add(foo);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(FooAggregate foo)
        {
            try
            {
                var model = this.store.First(storedFoo => storedFoo.Id == foo.Id);

                model.Value = foo.Value;

                return Task.CompletedTask;
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("UpdateAsync - Foo is not found in repository");
                throw;
            }
        }

        public Task DeleteAsync(int id)
        {
            try
            {
                var model = this.store.First(storedFoo => storedFoo.Id == id);

                this.store.Remove(model);

                return Task.CompletedTask;
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("DeleteAsync - Foo is not found in repository");
                throw;
            }

        }
    }
}
