using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class PhotoInAlbumQuery : IPhotoInAlbumQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public PhotoInAlbumQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<PhotoInAlbumDTO>> GetPhotoInAlbums(GetPhotoInAlbumsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<PhotoInAlbumDTO>()
                .From("PhotoInAlbum")
                .BuildQuery<PhotoInAlbumDTO>()
                .ExecuteToList();
        }
    }
}
