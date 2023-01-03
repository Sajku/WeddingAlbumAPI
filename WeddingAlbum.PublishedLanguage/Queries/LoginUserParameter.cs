using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class LoginUserParameter : IQuery<JwtDTO>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
