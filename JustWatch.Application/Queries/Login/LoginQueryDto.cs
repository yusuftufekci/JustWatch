using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Application.Queries.Login
{
    public class LoginQueryDto
    {
        public string Token { get; set; }
    }
}
