using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.Fields.Exceptions
{
    internal class InvalidLatitudeValueException : HarvestHubException
    {
        public double Value { get; }
        public InvalidLatitudeValueException(double value)
            : base($"Provided latitude value: {value} is invalid! Value should be a number between -90 and 90")
        {
            Value = value;
        }
    }
}
