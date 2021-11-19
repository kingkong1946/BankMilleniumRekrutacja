using BankMilleniumRekrutacja.Shared.Domain;
using System.Threading.Tasks;

namespace BankMilleniumRekrutacja.Shared.Infrastructure
{
    public interface Repository<T>
        where T: Aggregate
    {
        Task<T> GetAsync(int id);
        Task AddAsync(T aggregate);
        Task UpdateAsync(T aggregate);
        Task DeleteAsync(int id);
    }
}
