using MediatR;

namespace FinalProject.Application.Features.Tag.Queries
{
    public class GetTheMostPopularTags : IRequest<List<Domain.Entities.Tag>>
    {
        public int Count { get; set; }
    }
}
