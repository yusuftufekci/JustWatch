using JustWatch.Application.Common.Helpers.Authentication;
using JustWatch.Application.Common.Mediator;
using JustWatch.Application.Common.Responses;
using JustWatch.Domain.Entities.JustWatch;
using JustWatch.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Application.Queries.Login
{
    public class LoginQueryHandler : ICommandHandler<LoginQueryCommand,Response<LoginQueryDto>>
    {
        private readonly IJustWatchRepository<Users> _userRepository;
        public LoginQueryHandler(IJustWatchRepository<Users> _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<Response<LoginQueryDto>> Handle(LoginQueryCommand command, CancellationToken cancellationToken)
        {
                var user = await _userRepository.FindOneAsync(p => p.Username == command.UserName);
                if (user == null) return Response<LoginQueryDto>.Error("Cant find the username");

                if (AuthenticationHelper.VerifyPassword(command.Password, user.PasswordHash))
                {
                    var token = AuthenticationHelper.GenerateAccessToken(command.UserName);

                    return Response<LoginQueryDto>.Success(new LoginQueryDto { Token = new JwtSecurityTokenHandler().WriteToken(token) });

                }
                return Response<LoginQueryDto>.Error("Password is wrong");
        }
    }
}
