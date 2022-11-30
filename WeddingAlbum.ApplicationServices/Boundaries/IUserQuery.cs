using System.Threading.Tasks;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserQuery
    {
        Task<User> GetUserById(string id);
    }
}
