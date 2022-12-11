using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class UserFavouriteAlbumRepository : IUserFavouriteAlbumRepository
    {
        private readonly WeddingAlbumContext _context;

        public UserFavouriteAlbumRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(UserFavouriteAlbum userFavouriteAlbum)
        {
            await _context.UserFavouriteAlbums.AddAsync(userFavouriteAlbum);
        }
    }
}
