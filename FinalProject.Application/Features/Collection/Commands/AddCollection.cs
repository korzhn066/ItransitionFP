using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.Collection.Commands
{
    public record class AddCollection : IRequest
    {
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<Domain.Entities.Tag> Tags { get; set; } = new ();
    }
}
