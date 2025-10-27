using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Services.Fields.Application.Services
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync(double latitude, double longitude);
    }
}
