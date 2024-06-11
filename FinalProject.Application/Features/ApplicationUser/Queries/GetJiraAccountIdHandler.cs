using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ApplicationUser.Queries
{
    internal class GetJiraAccountIdHandler : IRequestHandler<GetJiraAccountId, string?>
    {
        private readonly IUserRepository _userRepository;

        public GetJiraAccountIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Handle(GetJiraAccountId request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstAsync(u => u.UserName == request.UserName);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return user.JiraAccountId;
        }
    }
}
