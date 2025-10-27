using HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects
{
    public record Amount
    {
        public double Value { get; }

        public Amount(double value)
        {
            if (value < 0)
            {
                throw new InvalidAmountValueException(value);
            }

            Value = value;
        }

        public static implicit operator Amount(double value) => new(value);

        public static implicit operator double(Amount amount) => amount.Value;
    }
}
