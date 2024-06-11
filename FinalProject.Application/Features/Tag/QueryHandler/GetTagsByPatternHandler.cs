using FinalProject.Application.Features.Tag.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Tag.QueryHandler
{
    internal class GetTagsByPatternHandler : IRequestHandler<GetTagsByPattern, List<Domain.Entities.Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagsByPatternHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<Domain.Entities.Tag>> Handle(GetTagsByPattern request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.LikeText(request.Count, request.Text, cancellationToken);
            
            return tags;
        }
    }
}
