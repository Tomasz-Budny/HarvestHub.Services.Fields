using HarvestHub.Services.Fields.Application.Dtos.Externals.GoogleGeoCode;
using HarvestHub.Services.Fields.Application.Services;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Services.Fields.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace HarvestHub.Services.Fields.Infrastructure.Services
{
    internal class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleApiOptions _googleApiOptions;

        public AddressService(HttpClient httpClient, IOptions<GoogleApiOptions> googleApiOptions)
        {
            _httpClient = httpClient;
            _googleApiOptions = googleApiOptions.Value;
        }
        public async Task<Address> GetAddressAsync(double latitude, double longitude)
        {
            var url = $"json?latlng={latitude.ToString().Replace(',', '.')},{longitude.ToString().Replace(',', '.')}&key={_googleApiOptions.Key}";
            var response = await _httpClient.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                return new Address("Nieznane", "Nieznane", null, "Nieznane");
            }

            var geoCodeDto = await response.Content.ReadFromJsonAsync<GeoCodeDto>();

            var country = geoCodeDto?.Results[0].Address_components.Find(a => a.Types.Contains("country"))?.Long_name ?? "Nieznane";
            var administrativeDivisionLevelOne = geoCodeDto?.Results[0].Address_components.Find(a => a.Types.Contains("administrative_area_level_1"))?.Long_name ?? "";
            var administrativeDivisionLevelTwo = geoCodeDto?.Results[0].Address_components.Find(a => a.Types.Contains("administrative_area_level_2"))?.Long_name ?? "";
            var city = geoCodeDto?.Results[0].Address_components.Find(a => a.Types.Contains("locality") || a.Types.Contains("postal_town"))?.Long_name ?? "Nieznane";

            return new Address(country, administrativeDivisionLevelOne, administrativeDivisionLevelTwo, city);
        }
    }
}
