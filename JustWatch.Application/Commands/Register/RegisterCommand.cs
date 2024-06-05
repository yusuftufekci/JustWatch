using JustWatch.Application.Common.Mediator;
using JustWatch.Application.Common.Responses;
using JustWatch.Application.Queries.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Application.Commands.Register
{
    public class RegisterCommand(string userName, string email, string password) : ICommand<Response>
    {
        [Required]
        public string Username { get; set; } = userName;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = email;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = password;
    }
}
