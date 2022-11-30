using WeddingAlbum.Common.Auth;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Claims;

namespace WeddingAlbum.Api.Infrastructure
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.Identity.Name;
        }

        public string UserId { get; }
    }
}
