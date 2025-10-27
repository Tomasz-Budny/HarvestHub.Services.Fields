namespace HarvestHub.Services.Fields.Core.Owners.ValueObjects
{
    public record LastName
    {
        public string Value { get; }

        public LastName(string value)
        {
            Value = value;
        }

        public static implicit operator LastName(string value) => new(value);

        public static implicit operator string(LastName lastName) => lastName.Value;
    }
}
