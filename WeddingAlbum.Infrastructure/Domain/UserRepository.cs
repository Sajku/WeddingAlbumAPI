using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Albums;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly WeddingAlbumContext _context;

        public UserRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Store(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetAsync(string id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserFavouriteAlbum> GetUserFavouriteAlbum(string userId, int id)
        {
            return await _context.UserFavouriteAlbums
                .SingleOrDefaultAsync(a => a.AlbumId == id && a.UserId == userId);
        }

        public async Task Add(UserInEvent userInEvent)
        {
            await _context.UserInEvents.AddAsync(userInEvent);
        }

        public async Task Add(UserFavouriteAlbum userFavouriteAlbum)
        {
            await _context.UserFavouriteAlbums.AddAsync(userFavouriteAlbum);
        }

        public void DeleteUserFavouriteAlbum(UserFavouriteAlbum album)
        {
            _context.UserFavouriteAlbums.Remove(album);
            _context.SaveChanges();
        }
    }
}
