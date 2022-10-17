using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Samples;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases
{
    public class AddSampleUseCase : ICommandHandler<AddSampleCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddSampleUseCase(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddSampleCommand command)
        {
            _sampleRepository.EnsureThatSampleDoesNotExist(command.Name);

            _sampleRepository.Store(new Sample(command.Name));
            await _unitOfWork.Save();
        }
    }
}
