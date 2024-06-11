using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Collection.QueryHandlers
{
    internal class GetCollectionsByUsernameHandler : IRequestHandler<GetCollectionsByUsername, List<Domain.Entities.Collection>>
    {
        private readonly ICollectionRepository _collectionRepository;

        public GetCollectionsByUsernameHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Domain.Entities.Collection>> Handle(GetCollectionsByUsername request, CancellationToken cancellationToken)
        {
            var collections = await _collectionRepository.GetByUsernameAsync(
                request.Username,
                request.Count,
                request.Page,
                cancellationToken);

            return collections;
        }
    }
}
