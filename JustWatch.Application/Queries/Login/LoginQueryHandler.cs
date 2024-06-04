using JustWatch.Application.Common.Helpers.Authentication;
using JustWatch.Application.Common.Mediator;
using JustWatch.Application.Common.Responses;
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
        public async Task<Response<LoginQueryDto>> Handle(LoginQueryCommand command, CancellationToken cancellationToken)
        {
            if (command is { UserName: "demo", Password: "password" })
            {
                // generate token for user
                var token = AuthenticationHelper.GenerateAccessToken(command.UserName);
                // return access token for user's use
                return Response<LoginQueryDto>.Success(new LoginQueryDto { Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Response<LoginQueryDto>.Error("Cant login");

        }
    }
}
