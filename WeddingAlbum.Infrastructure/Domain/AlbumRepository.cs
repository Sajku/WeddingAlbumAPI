using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Albums;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly WeddingAlbumContext _context;

        public AlbumRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(Album album)
        {
            await _context.Albums.AddAsync(album);
        }
    }
}
