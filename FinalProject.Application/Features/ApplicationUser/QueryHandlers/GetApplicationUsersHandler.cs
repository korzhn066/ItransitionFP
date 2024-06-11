using FinalProject.Application.Features.ApplicationUser.Queries;
using FinalProject.Application.Models;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Application.Features.ApplicationUser.QueryHandlers
{
    internal class GetApplicationUsersHandler : IRequestHandler<GetApplicationUsers, List<ApplicationUserWithAdminRole>>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public GetApplicationUsersHandler(IUserRepository userRepository, UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<List<ApplicationUserWithAdminRole>> Handle(GetApplicationUsers request, CancellationToken cancellationToken)
        {
            var result = new List<ApplicationUserWithAdminRole>();

            foreach (var user in await _userRepository.GetAllAsync(cancellationToken))
            {
                result.Add(new ApplicationUserWithAdminRole
                {
                    ApplicationUser = user,
                    IsAdmin = await _userManager.IsInRoleAsync(user, "Admin")
                });
            }

            return result;
        }
    }
}
