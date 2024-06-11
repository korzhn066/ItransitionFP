using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ApplicationUser.Commands
{
    public class ChangeUserEmail : IRequest
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
