using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddAlbumCommand : ICommand
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string UserId { get; set; } // TEMPORARY
        public int MainPhotoId { get; set; }
        public int EventId { get; set; }
    }
}
