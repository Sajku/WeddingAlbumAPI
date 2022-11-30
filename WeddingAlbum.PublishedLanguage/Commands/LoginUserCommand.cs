using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
