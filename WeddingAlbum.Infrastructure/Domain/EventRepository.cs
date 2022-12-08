using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Event;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class EventRepository : IEventRepository
    {
        private readonly WeddingAlbumContext _context;

        public EventRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(Event e)
        {
            await _context.Events.AddAsync(e);
        }
    }
}
