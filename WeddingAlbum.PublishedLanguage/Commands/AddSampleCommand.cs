using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddSampleCommand : ICommand
    {
        public string Name { get; set; }
    }
}
