using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using System.Text.RegularExpressions;

namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public record HexColor
    {
        private static readonly Regex Regex = new(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        public string Value { get; }

        public HexColor(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value))
            {
                throw new InvalidHexColorException(value);
            }

            Value = value;
        }

        public static implicit operator HexColor(string value) => new(value);

        public static implicit operator string(HexColor hexColor) => hexColor.Value;
    }
}
