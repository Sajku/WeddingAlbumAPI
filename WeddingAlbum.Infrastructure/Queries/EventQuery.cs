using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class EventQuery : IEventQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public EventQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }
        public async Task<List<EventDTO>> GetEvents(GetEventsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<EventDTO>()
                .From("Event")
                .BuildQuery<EventDTO>()
                .ExecuteToList();
        }
        public async Task<EventDTO> GetEventDetails(GetEventDetailsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<EventDTO>()
                .From("Event")
                .Where("Id", query.EventId)
                .BuildQuery<EventDTO>()
                .ExecuteToFirstElement();
        }

        public async Task<List<UserAlbumInEventDTO>> GetEventAlbums(GetEventAlbumsParameter query)
        {
            var publicAlbums = await _sqlQueryBuilder
                .SelectAllProperties<UserAlbumInEventDTO>("PhotosNumber")
                .From("VW_EventAlbums")
                .Where("EventId", query.EventId)
                .Where("IsPrivate", false)
                .BuildQuery<UserAlbumInEventDTO>()
                .ExecuteToList();

            var privateAlbums = await _sqlQueryBuilder
                .SelectAllProperties<UserAlbumInEventDTO>("PhotosNumber")
                .From("VW_EventAlbums")
                .Where("EventId", query.EventId)
                .Where("UserId", query.UserId)
                .Where("IsPrivate", true)
                .BuildQuery<UserAlbumInEventDTO>()
                .ExecuteToList();

            var allAlbums = publicAlbums.Concat(privateAlbums).ToList();

            var albumsIds = allAlbums.Select(x => x.AlbumId).ToList();

            var photosNumbers = await _sqlQueryBuilder
                .SelectAllProperties<AlbumPhotosNumberDTO>()
                .From("VW_AlbumsPhotosNumber")
                .WhereIn("AlbumId", albumsIds)
                .BuildQuery<AlbumPhotosNumberDTO>()
                .ExecuteToList();

            allAlbums = allAlbums.Select(album =>
            {
                album.PhotosNumber = photosNumbers.Where(photoNumber => photoNumber.AlbumId == album.AlbumId).Select(x => x.Number).FirstOrDefault();
                return album;
            }).ToList();

            return allAlbums;
        }

        public async Task<List<ShortPhotoDTO>> GetEventPhotos(GetEventPhotosParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<ShortPhotoDTO>()
                .From("Photo")
                .Where("EventId", query.EventId)
                .BuildQuery<ShortPhotoDTO>()
                .ExecuteToList();
        }
    }
}
