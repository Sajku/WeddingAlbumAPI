using System.Threading.Tasks;
using WeddingAlbum.Domain.Events;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IEventRepository
    {
        Task Add(Event e);
    }
}