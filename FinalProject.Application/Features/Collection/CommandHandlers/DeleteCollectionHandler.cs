using FinalProject.Application.Features.Collection.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Collection.CommandHandlers
{
    internal class DeleteCollectionHandler : IRequestHandler<DeleteCollection>
    {
        private readonly ICollectionRepository _collectionRepository;
        public DeleteCollectionHandler(ICollectionRepository collectionRepository) 
        { 
            _collectionRepository = collectionRepository;
        }
        public async Task Handle(DeleteCollection request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetFirstAsync(c => c.Id == request.Id, cancellationToken);

            if (collection is null) 
                throw new ArgumentNullException(nameof(collection));

            _collectionRepository.Delete(collection);

            await _collectionRepository.SaveChangesAsync();
        }
    }
}
