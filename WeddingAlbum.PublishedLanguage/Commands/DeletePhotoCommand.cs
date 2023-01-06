using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class DeletePhotoCommand : ICommand
    {
        public int PhotoId { get; set; }
    }
}
