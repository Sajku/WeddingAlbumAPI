using System.Threading.Tasks;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IEventRepository
    {
        Task Add(Event e);
        Task<TempEventTypeDTO> CheckCode(string code);
    }
}