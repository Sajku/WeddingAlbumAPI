using System.Security.Claims;

namespace WeddingAlbum.Common.Auth
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
