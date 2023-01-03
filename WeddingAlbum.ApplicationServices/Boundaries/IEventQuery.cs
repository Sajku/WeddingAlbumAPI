using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IEventQuery
    {
        Task<List<EventDTO>> GetEvents(GetEventsParameter query);
        Task<EventDTO> GetEventDetails(GetEventDetailsParameter query);
        Task<List<UserAlbumInEventDTO>> GetEventAlbums(GetEventAlbumsParameter query);
        Task<List<ShortPhotoDTO>> GetEventPhotos(GetEventPhotosParameter query);
    }
}
