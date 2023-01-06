using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class DeleteAlbumCommand : ICommand
    {
        public int AlbumId { get; set; }
    }
}
