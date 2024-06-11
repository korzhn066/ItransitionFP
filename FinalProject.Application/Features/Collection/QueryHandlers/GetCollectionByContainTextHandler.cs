using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    public class GetCollectionsByContainTextHandler : IRequestHandler<GetCollectionsByContainText, List<Domain.Entities.Collection>>
    {
        private readonly ICollectionRepository _collectionRepository;

        public GetCollectionsByContainTextHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public Task<List<Domain.Entities.Collection>> Handle(GetCollectionsByContainText request, CancellationToken cancellationToken)
        {
            var collections = _collectionRepository.ContainAsync(request.Text, request.Count, cancellationToken);

            return collections;
        }
    }
}
