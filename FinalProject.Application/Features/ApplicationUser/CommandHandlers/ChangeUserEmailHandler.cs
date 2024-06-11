using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.ApplicationUser.CommandHandlers
{
    internal class ChangeUserEmailHandler : IRequestHandler<ChangeUserEmail>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ChangeUserEmail request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstAsync(u => u.UserName == request.UserName);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.Email = request.Email;

            await _userRepository.SaveChangesAsync();
        }
    }
}
