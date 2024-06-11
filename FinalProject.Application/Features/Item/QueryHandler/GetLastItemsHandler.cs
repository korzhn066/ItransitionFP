using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetLastItemsHandler : IRequestHandler<GetLastItems, List<Domain.Entities.Item>>
    {
        private readonly IItemRepository _itemRepository;

        public GetLastItemsHandler(IItemRepository itemRepository) 
        { 
            _itemRepository = itemRepository;
        }

        public async Task<List<Domain.Entities.Item>> Handle(GetLastItems request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetLastAsync(request.Count);
        }
    }
}
