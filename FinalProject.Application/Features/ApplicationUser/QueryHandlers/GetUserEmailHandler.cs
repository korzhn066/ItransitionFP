using FinalProject.Application.Features.ApplicationUser.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ApplicationUser.QueryHandlers
{
    internal class GetUserEmailHandler : IRequestHandler<GetUserEmail, string?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Handle(GetUserEmail request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstAsync(u => u.UserName == request.UserName);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return user.Email;
        }
    }
}
