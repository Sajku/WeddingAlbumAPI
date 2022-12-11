using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class UserInEventRepository : IUserInEventRepository
    {
        private readonly WeddingAlbumContext _context;

        public UserInEventRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(UserInEvent userInEvent)
        {
            await _context.UserInEvents.AddAsync(userInEvent);
        }
    }
}
