

using FinalProject.Application.Features.Collection.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Collection.CommandHandlers
{
    internal class UpdateCollectionHandler : IRequestHandler<UpdateCollection>
    {
        private readonly ICollectionRepository _collectionRepository;

        public UpdateCollectionHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task Handle(UpdateCollection request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetFirstAsync(c => c.Id == request.Id, cancellationToken);
        
            if (collection is null) 
                throw new ArgumentNullException(nameof(collection));

            collection.Name = request.Name;
            collection.Description = request.Description;

            await _collectionRepository.SaveChangesAsync();
        }
    }
}
