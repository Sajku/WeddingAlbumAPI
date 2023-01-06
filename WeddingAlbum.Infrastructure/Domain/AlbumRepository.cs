using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Albums;
using WeddingAlbum.Domain.Photos;
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

        public async Task<Album> GetAlbum(int id)
        {
            return await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void DeleteAlbum(Album album)
        {
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }
    }
}
