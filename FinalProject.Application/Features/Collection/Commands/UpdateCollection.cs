using MediatR;

namespace FinalProject.Application.Features.Collection.Commands
{
    public class UpdateCollection : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
