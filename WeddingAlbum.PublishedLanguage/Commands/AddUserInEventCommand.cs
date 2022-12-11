using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddUserInEventCommand : ICommand
    {
        public string UserId { get; set; } //Temporary
        public int EventId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
