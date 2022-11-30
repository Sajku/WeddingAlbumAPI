using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class LoginUserUseCase : IQueryHandler<LoginUserParameter, JwtDTO>
    {
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserQuery _userQuery;

        public LoginUserUseCase(
            IEncrypter encrypter,
            IJwtHandler jwtHandler,
            IUserQuery userQuery)
        {
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _userQuery = userQuery;
        }

        public async Task<JwtDTO> Handle(LoginUserParameter parameter)
        {

            var token = _jwtHandler.CreateToken(parameter.Id, "user");
            var user = await _userQuery.GetUserById(parameter.Id);
            if (user == null)
            {
                return null;
            }
            var hash = _encrypter.GetHash(parameter.Password, user.Salt);

            if (user.Hash == hash)
            {
                return token;
            }
            throw new Exception("Invalid credentials");
        }
    }
}
