using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddUserFavouriteAlbumCommand : ICommand
    {
        public string UserId { get; set; } //Temporary
        public int AlbumId { get; set; }
    }
}
