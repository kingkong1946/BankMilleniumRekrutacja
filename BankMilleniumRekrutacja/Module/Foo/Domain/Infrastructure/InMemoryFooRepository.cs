namespace BankMilleniumRekrutacja.Shared.Infrastructure
{
    using BankMilleniumRekrutacja.Module.Foo.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryFooRepository: Repository<Foo>
    {
        private readonly IList<Foo> store = new List<Foo>();

        public void Save(Foo foo)
        {
            var model = this.store.FirstOrDefault(storedFoo => storedFoo.Id == foo.Id);

            if (model != null)
            {
                model.Value = foo.Value;
            } 
            else
            {
                model = foo;
                this.store.Add(model);
            }
        }
    }
}
