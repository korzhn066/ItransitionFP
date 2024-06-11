using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ApplicationUser.Queries
{
    public class GetJiraAccountId : IRequest<string?>
    {
        public string UserName { get; set; } = null!;
    }
}
