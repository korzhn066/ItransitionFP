using MediatR;

namespace FinalProject.Application.Features.ApplicationUser.Commands
{
    public class BlockUsers : IRequest
    {
        public List<string> UsersId { get; set; } = null!;
    }
}
