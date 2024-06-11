using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Application.Features.ApplicationUser.CommandHandlers
{
    internal class BlockUsersHandler : IRequestHandler<BlockUsers>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public BlockUsersHandler(
            UserManager<Domain.Entities.ApplicationUser> userManager, 
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task Handle(BlockUsers request, CancellationToken cancellationToken)
        {
            foreach (var userId in request.UsersId)
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is null) 
                    throw new ArgumentNullException(nameof(user));

                user.Status = Domain.Enums.UserStatus.Block;
            }

            await _userRepository.SaveChangesAsync();
        }
    }
}
