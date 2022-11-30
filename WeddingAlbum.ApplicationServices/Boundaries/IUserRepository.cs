using System.Threading.Tasks;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserRepository
    {
        Task Store(User user);
        Task<User> GetAsync(string id);
    }
}
