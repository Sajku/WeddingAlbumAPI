using WeddingAlbum.Domain.Samples;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface ISampleRepository
    {
        void EnsureThatSampleDoesNotExist(string name);
        void Store(Sample sample);
    }
}
