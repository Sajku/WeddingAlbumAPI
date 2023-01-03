using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetEventDetailsParameter : IQuery<EventDTO>
    {
        public int EventId { get; set; }
    }
}
