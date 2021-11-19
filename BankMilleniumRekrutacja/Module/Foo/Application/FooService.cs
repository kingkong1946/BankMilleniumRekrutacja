using AutoMapper;
using BankMilleniumRekrutacja.Module.Foo.Domain;
using BankMilleniumRekrutacja.Shared.Infrastructure;
using BankMilleniumRekrutacja.ViewModels;
using System;
using System.Threading.Tasks;

namespace BankMilleniumRekrutacja.Module.Foo.Application
{
    public class FooService
    {
        private readonly Repository<FooAggregate> repository;
        private readonly IMapper mapper;

        public FooService(Repository<FooAggregate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<FooDto> GetAsync(int id)
        {
            var foo = await this.repository.GetAsync(id);
            return this.mapper.Map<FooDto>(foo);
        }

        public async Task AddAsync(FooDto dto)
        {
            var foo = this.mapper.Map<FooAggregate>(dto);
            await this.repository.AddAsync(foo);
        }

        public async Task UpdateAsync(FooDto dto)
        {
            var foo = this.mapper.Map<FooAggregate>(dto);
            await this.repository.UpdateAsync(foo);
        }

        public async Task DeleteAsync(int id)
        {
            await this.repository.DeleteAsync(id);
        }
    }
}
