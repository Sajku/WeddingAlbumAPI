using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class PhotoQuery : IPhotoQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public PhotoQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<PhotoDTO>> GetPhotos(GetPhotosParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<PhotoDTO>()
                .From("Photo")
                .BuildQuery<PhotoDTO>()
                .ExecuteToList();
        }
    }
}
