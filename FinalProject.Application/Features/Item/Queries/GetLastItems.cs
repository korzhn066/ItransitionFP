using MediatR;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetLastItems : IRequest<List<Domain.Entities.Item>>
    {
        public int Count { get; set; }
    }
}
