using System;
using System.Threading.Tasks;
using EnsureThat;
using WeddingAlbum.Common.Exceptions;
using WeddingAlbum.Domain;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeddingAlbumContext _context;

        public UnitOfWork(WeddingAlbumContext context)
        {
            EnsureArg.IsNotNull(context, nameof(context));

            _context = context;
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex.InnerException);
            }
        }
    }
}
