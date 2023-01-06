using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class DeletePhotoFromAlbumCommand : ICommand
    {
        public int PhotoId { get; set; }
        public int AlbumId { get; set; }
    }
}
