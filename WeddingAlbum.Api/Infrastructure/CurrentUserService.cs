using WeddingAlbum.Common.Auth;
using Microsoft.AspNetCore.Http;
using IdentityModel;

namespace WeddingAlbum.Api.Infrastructure
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Subject)?.Value;
        }

        public string UserId { get; }
    }
}
