using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class AlbumQuery : IAlbumQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public AlbumQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<AlbumDTO>> GetAlbums(GetAlbumsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<AlbumDTO>()
                .From("Album")
                .BuildQuery<AlbumDTO>()
                .ExecuteToList();
        }

        public async Task<List<ShortPhotoDTO>> GetAlbumPhotos(GetAlbumPhotosParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<ShortPhotoDTO>()
                .From("VW_AlbumsPhotos")
                .Where("AlbumId", query.AlbumId)
                .BuildQuery<ShortPhotoDTO>()
                .ExecuteToList();
        }
    }
}
