using System.Threading.Tasks;
using WeddingAlbum.Domain.Event;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IEventRepository
    {
        Task Add(Event e);
    }
}