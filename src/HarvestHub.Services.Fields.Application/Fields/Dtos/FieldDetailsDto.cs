using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Services.Fields.Core.Fields.Primitives;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record FieldDetailsDto(
        string Name, 
        PointDto Center, 
        DateTime CreatedAt, 
        double Area, 
        FieldClassStatus FieldClass, 
        OwnershipStatus OwnershipStatus,
        AddressDto Address, 
        string Color
    );
}
