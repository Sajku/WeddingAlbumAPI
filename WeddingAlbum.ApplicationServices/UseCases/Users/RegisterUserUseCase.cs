using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class RegisterUserUseCase : ICommandHandler<RegisterUserCommand>
    {
        private readonly IEncrypter _encrypter;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(
            IEncrypter encrypter,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _encrypter = encrypter;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegisterUserCommand command)
        {
            var salt = _encrypter.GetSalt(command.Password);
            var hash = _encrypter.GetHash(command.Password, salt);

            var user = new User(
                command.FirstName,
                command.LastName,
                salt,
                hash);

            await _userRepository.Store(user);
            await _unitOfWork.Save();
        }
    }
}
