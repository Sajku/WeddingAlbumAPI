using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class DeleteUserFavouriteAlbumCommand : ICommand
    {
        public string UserId { get; set; } //Temporary
        public int AlbumId { get; set; }
    }
}
