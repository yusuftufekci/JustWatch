using JustWatch.Application.Common.Helpers.Authentication;
using JustWatch.Application.Common.Responses;
using JustWatch.Application.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JustWatch.API.Controllers.AuthenticationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<Response<LoginQueryDto>> Login([FromBody] LoginQueryCommand model)
        {
            return await _mediator.Send(new LoginQueryCommand(model.UserName,model.Password));

        }
    }
}
