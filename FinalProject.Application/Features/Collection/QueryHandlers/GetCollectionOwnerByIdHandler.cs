using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    internal class GetCollectionOwnerByIdHandler : IRequestHandler<GetCollectionOwnerById, string>
    {
        private readonly ICollectionRepository _collectionRepository;

        public GetCollectionOwnerByIdHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }
        public async Task<string> Handle(GetCollectionOwnerById request, CancellationToken cancellationToken)
        {
            var owner = await _collectionRepository.GetOwnerByIdAsync(request.Id, cancellationToken);

            return owner;
        }
    }
}
