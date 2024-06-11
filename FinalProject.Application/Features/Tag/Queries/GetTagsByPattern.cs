using MediatR;

namespace FinalProject.Application.Features.Tag.Queries
{
    public class GetTagsByPattern : IRequest<List<Domain.Entities.Tag>>
    {
        public int Count { get; set; }
        public string Text { get; set; } = null!;
    }
}
