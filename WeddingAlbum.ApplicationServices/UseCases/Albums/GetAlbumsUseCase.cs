using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Albums
{
    public class GetAlbumsUseCase : IQueryHandler<GetAlbumsParameter, List<AlbumDTO>>
    {
        private readonly IAlbumQuery _albumQuery;

        public GetAlbumsUseCase(IAlbumQuery albumQuery)
        {
            _albumQuery = albumQuery;
        }

        public async Task<List<AlbumDTO>> Handle(GetAlbumsParameter query)
        {
            return await _albumQuery.GetAlbums(query);
        }
    }
}
