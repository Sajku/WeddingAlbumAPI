using System.Threading.Tasks;

namespace WeddingAlbum.Domain
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
