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
    internal class GetCollectionNameByIdHandler : IRequestHandler<GetCollectionNameByItemId, string>
    {
        private readonly IItemRepository _itemRepository;

        public GetCollectionNameByIdHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<string> Handle(GetCollectionNameByItemId request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetCollectionNameByItemId(request.Id); 
        }
    }
}
