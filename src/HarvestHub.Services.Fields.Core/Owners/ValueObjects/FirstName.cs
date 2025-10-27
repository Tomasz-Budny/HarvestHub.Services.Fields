namespace HarvestHub.Services.Fields.Core.Owners.ValueObjects
{
    public record FirstName
    {
        public string Value { get; }

        public FirstName(string value)
        {
            Value = value;
        }

        public static implicit operator FirstName(string value) => new(value);

        public static implicit operator string(FirstName firstName) => firstName.Value;
    }
}
