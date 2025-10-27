using HarvestHub.Services.Fields.Application.Dtos;

namespace HarvestHub.Services.Fields.Application.Owners.Dtos
{
    public record StartLocationDto(
        PointDto Coordinates,
        AddressDto Address
    );
}
