using Mapster;
using proAdministration.Data.Entities;
using proAdministration.Shared;

namespace proAdministration.API.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDetailsDto>()
            .Map(dest => dest.Address,
                src => $"{src.Address.Street}\n{src.Address.PostalCode} {src.Address.City}")
            .Map(dest => dest.State, src => src.Address.State)
            .Map(dest => dest.Country, src => src.Address.Country);

        config.NewConfig<CustomerRequest, Customer>()
            .AfterMapping((src, dest) => dest.Address = new Address
            {
                Street = src.Street,
                City = src.City,
                State = src.State,
                PostalCode = src.PostalCode,
                Country = src.Country
            });
    }
}