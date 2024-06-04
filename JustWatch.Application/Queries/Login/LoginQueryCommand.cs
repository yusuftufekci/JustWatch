using JustWatch.Application.Common.Mediator;
using JustWatch.Application.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JustWatch.Application.Queries.Login
{
    public class LoginQueryCommand : ICommand<Response<LoginQueryDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginQueryCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
    
}
