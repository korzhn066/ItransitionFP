using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public class GetCollectionsByUsername : IRequest<List<Domain.Entities.Collection>>
    {
        public string Username { get; set; } = null!;
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
