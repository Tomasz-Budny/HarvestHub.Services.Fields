using HarvestHub.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HarvestHub.Shared.Authentication
{
    internal class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetUserId
        {
            get
            {
                var sub = (_httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)) ?? throw new UnauthenticatedException();
                var isValid = Guid.TryParse(sub.Value, out Guid subId);
                if (!isValid)
                {
                    throw new UnauthenticatedException();
                }

                return subId;
            }
        }
    }
}
