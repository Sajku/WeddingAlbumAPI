using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.Infrastructure.DataModel.Context;
using WeddingAlbum.PublishedLanguage.Dtos;

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

        public async Task<TempEventTypeDTO> CheckCode(string code)
        {
            var isGuestCode = await _context.Events
                .SingleOrDefaultAsync(e => e.GuestCode == code);

            if (isGuestCode != null)
            {
                return new TempEventTypeDTO { Id = isGuestCode.Id, IsGuest = true };
            }

            var isAdminCode = await _context.Events
                .SingleOrDefaultAsync(e => e.AdminCode == code);

            if (isAdminCode != null)
            {
                return new TempEventTypeDTO { Id = isGuestCode.Id, IsGuest = false };
            }

            return new TempEventTypeDTO { Id = 0, IsGuest = true };
        }
    }
}
