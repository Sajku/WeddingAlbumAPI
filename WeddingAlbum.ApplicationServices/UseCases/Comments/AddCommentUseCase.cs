using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
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
        private readonly ICurrentUserService _currentUserService;

        public AddCommentUseCase(ICommentRepository commentRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddCommentCommand command)
        {
            command.UserId ??= _currentUserService.UserId;

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
