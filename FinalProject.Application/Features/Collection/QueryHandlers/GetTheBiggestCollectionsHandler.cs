using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    internal class GetTheBiggestCollectionsHandler : IRequestHandler<GetTheBiggestCollections, List<Domain.Entities.Collection>>
    {
        private readonly ICollectionRepository _collectionRepository;
        public GetTheBiggestCollectionsHandler(ICollectionRepository collectionRepository) 
        { 
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Domain.Entities.Collection>> Handle(GetTheBiggestCollections request, CancellationToken cancellationToken)
        {
            return await _collectionRepository.GetTheBiggestAsync(request.Count, cancellationToken);
        }
    }
}
