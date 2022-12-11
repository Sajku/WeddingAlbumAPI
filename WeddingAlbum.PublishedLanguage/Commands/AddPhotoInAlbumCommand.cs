using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddPhotoInAlbumCommand : ICommand
    {
        public int AlbumId { get; set; } //Temporary
        public int PhotoId { get; set; }
    }
}
