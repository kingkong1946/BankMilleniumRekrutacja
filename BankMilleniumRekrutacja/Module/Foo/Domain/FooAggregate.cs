using BankMilleniumRekrutacja.Shared.Domain;

namespace BankMilleniumRekrutacja.Module.Foo.Domain
{
    public class FooAggregate : Aggregate
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
