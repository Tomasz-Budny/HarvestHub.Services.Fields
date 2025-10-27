namespace HarvestHub.Services.Fields.Application.Dtos
{
    public record AddressDto(
        string Country, 
        string AdministrativeDivisionLevelOne, 
        string? AdministrativeDivisionLevelTwo, 
        string City
    );
}
