using HarvestHub.Shared.Events;

namespace HarvestHub.Services.Users.Shared.Events
{
    public record UserCreated(Guid Id, string FirstName, string LastName, string Email, Guid VerificationToken) : IEvent;
}
