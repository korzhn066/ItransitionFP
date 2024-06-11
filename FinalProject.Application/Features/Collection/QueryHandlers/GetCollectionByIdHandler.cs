using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    internal class GetCollectionByIdHandler : IRequestHandler<GetCollectionById, Domain.Entities.Collection>
    {
        private readonly ICollectionRepository _collectionRepository;
        public GetCollectionByIdHandler(ICollectionRepository collectionRepository) 
        {
            _collectionRepository = collectionRepository;   
        }

        public async Task<Domain.Entities.Collection> Handle(GetCollectionById request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetFirstAsync(c => c.Id == request.Id, cancellationToken);

            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            return collection;
        }
    }
}
