using BankMilleniumRekrutacja.Shared.Domain;

namespace BankMilleniumRekrutacja.Module.Foo.Domain
{
    public class Foo : Aggregate
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
