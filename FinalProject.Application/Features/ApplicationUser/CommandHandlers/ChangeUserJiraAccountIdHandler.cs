using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ApplicationUser.CommandHandlers
{
    internal class ChangeUserJiraAccountIdHandler : IRequestHandler<ChangeUserJiraAccountId>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserJiraAccountIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ChangeUserJiraAccountId request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstAsync(u => u.UserName == request.UserName);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.JiraAccountId = request.JiraAccountId;

            await _userRepository.SaveChangesAsync();
        }
    }
}
