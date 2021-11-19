namespace BankMilleniumRekrutacja.Module.Foo.Application
{
    using AutoMapper;
    using BankMilleniumRekrutacja.Models;
    using BankMilleniumRekrutacja.Module.Foo.Domain;
    using BankMilleniumRekrutacja.ViewModels;

    public class FooAutoMapperProfile : Profile
    {
        public FooAutoMapperProfile()
        {
            this.CreateMap<FooRequest, FooDto>();

            this.CreateMap<FooAggregate, FooDto>()
                .ReverseMap();

            this.CreateMap<FooResource, FooDto>()
                .ReverseMap();
        }
    }
}
