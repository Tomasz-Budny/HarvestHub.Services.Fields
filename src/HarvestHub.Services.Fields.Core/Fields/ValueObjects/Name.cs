namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }

        public static implicit operator Name(string value) => new(value);

        public static implicit operator string(Name name) => name.Value;
    }
}
