using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    internal class GetCollectionTagsByIdHandler : IRequestHandler<GetCollectionTagsById, List<Domain.Entities.Tag>>
    {
        private readonly ICollectionRepository _collectionRepository;

        public GetCollectionTagsByIdHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Domain.Entities.Tag>> Handle(GetCollectionTagsById request, CancellationToken cancellationToken)
        {
            var tags = await _collectionRepository.GetTagsByIdAsync(request.Id, cancellationToken);

            return tags;
        }
    }
}
