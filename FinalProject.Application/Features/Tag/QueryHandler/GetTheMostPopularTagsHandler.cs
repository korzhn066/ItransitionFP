using FinalProject.Application.Features.Tag.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Tag.QueryHandler
{
    internal class GetTheMostPopularTagsHandler : IRequestHandler<GetTheMostPopularTags, List<Domain.Entities.Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTheMostPopularTagsHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<Domain.Entities.Tag>> Handle(GetTheMostPopularTags request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.GetTheMostPopular(request.Count, cancellationToken);

            return tags;
        }
    }
}
