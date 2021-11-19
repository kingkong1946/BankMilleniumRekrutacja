using BankMilleniumRekrutacja.Shared.Domain;

namespace BankMilleniumRekrutacja.Shared.Infrastructure
{
    public interface Repository<T>
        where T: Aggregate
    {
        void Save(T aggregate);
    }
}
