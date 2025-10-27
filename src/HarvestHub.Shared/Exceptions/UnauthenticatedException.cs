namespace HarvestHub.Shared.Exceptions
{
    internal class UnauthenticatedException : HarvestHubException
    {
        public UnauthenticatedException() : base("User is not authenticated!")
        {
        }
    }
}
