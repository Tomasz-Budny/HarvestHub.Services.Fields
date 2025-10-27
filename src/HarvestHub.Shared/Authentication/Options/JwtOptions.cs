namespace HarvestHub.Shared.Authentication.Options
{
    public class JwtOptions
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; }
        public TimeSpan Expiry { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
    }
}
