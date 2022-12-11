using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Comments;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Comments
{
    public class AddCommentUseCase : ICommandHandler<AddCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCommentUseCase(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddCommentCommand command)
        {
            var c = new Comment(
                command.Content,
                command.Date,
                command.UserId,
                command.PhotoId);
            await _commentRepository.Add(c);
            await _unitOfWork.Save();
        }
    }
}
