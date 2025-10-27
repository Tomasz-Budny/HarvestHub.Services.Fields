using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Services.Fields.Application.Mappers
{
    public static class AddressMapper
    {
        public static AddressDto MapToDto(Address address)
        {
            return new AddressDto(address.Country, address.AdministrativeDivisionLevelOne, address.AdministrativeDivisionLevelTwo, address.City);
        }
    }
}
