using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddUserInEventByCodeCommand : ICommand
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
