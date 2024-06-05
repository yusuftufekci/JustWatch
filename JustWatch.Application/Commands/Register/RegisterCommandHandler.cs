using JustWatch.Application.Common.Helpers.Authentication;
using JustWatch.Application.Common.Mediator;
using JustWatch.Application.Common.Responses;
using JustWatch.Application.Queries.Login;
using JustWatch.Domain.Entities.JustWatch;
using JustWatch.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Application.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, Response>
    {
        private readonly IJustWatchRepository<Users> _userRepository;
        public RegisterCommandHandler(IJustWatchRepository<Users> _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<Response> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindOneAsync(p=>p.Username == command.Username);
            if (user != null) return Response.Error("There is already an user with that username");

            await _userRepository.AddAsync(new Users
            {
                Username = command.Username,
                PasswordHash = AuthenticationHelper.HashPassword(command.Password),
                Email = command.Email,
            });
            await _userRepository.SaveChangesAsync();
            return Response.Success("Complete register.");
        }

       
    }
}
