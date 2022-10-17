using System.Linq;
using EnsureThat;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Exceptions;
using WeddingAlbum.Domain.Samples;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class SampleRepository : ISampleRepository
    {
        private readonly WeddingAlbumContext _context;

        public SampleRepository(WeddingAlbumContext context)
        {
            EnsureArg.IsNotNull(context, nameof(context));
            _context = context;
        }

        public void EnsureThatSampleDoesNotExist(string name)
        {
            var sample = _context.Samples.FirstOrDefault(r => r.Name == name);
            if (sample != null)
            {
                throw new DomainException($"Provided sample name: \"{name}\" already exist.");
            }
        }

        public void Store(Sample sample)
        {
            _context.Samples.Add(sample);
        }
    }
}
