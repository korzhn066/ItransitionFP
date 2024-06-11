using MediatR;

namespace FinalProject.Application.Features.ApplicationUser.Commands
{
    public class UnblockUsers : IRequest
    {
        public List<string> UsersId { get; set; } = null!;
    }
}
