namespace HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects
{
    public record Address
    {
        public string Country { get; }
        public string AdministrativeDivisionLevelOne { get; }
        public string? AdministrativeDivisionLevelTwo { get; }
        public string City { get; }

        public Address(string country, string administrativeDivisionLevelOne, string administrativeDivisionLevelTwo, string city)
        {
            Country = country;
            AdministrativeDivisionLevelOne = administrativeDivisionLevelOne;
            AdministrativeDivisionLevelTwo = administrativeDivisionLevelTwo;
            City = city;
        }

        public static Address Create(string value)
        {
            var splitAddress = value.Split(',');
            return new Address(splitAddress[0], splitAddress[1], splitAddress[2], splitAddress.Last());
        }

        public override string ToString() 
            => $"{Country},{AdministrativeDivisionLevelOne},{AdministrativeDivisionLevelTwo},{City}";
    }
}
