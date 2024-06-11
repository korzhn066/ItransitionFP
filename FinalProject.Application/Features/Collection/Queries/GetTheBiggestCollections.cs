using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public record GetTheBiggestCollections : IRequest<List<Domain.Entities.Collection>>
    {
        public int Count { get; set; } 
    }
}
