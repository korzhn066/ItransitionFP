using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public class GetCollectionsByContainText : IRequest<List<Domain.Entities.Collection>>
    {
        public string Text { get; set; } = null!;
        public int Count { get; set; }
    }
}
