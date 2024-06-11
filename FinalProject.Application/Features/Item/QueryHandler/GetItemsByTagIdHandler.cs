using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetItemsByTagIdHandler : IRequestHandler<GetItemsByTagId, List<Domain.Entities.Item?>>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemsByTagIdHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Domain.Entities.Item>> Handle(GetItemsByTagId request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllByTagId(request.TagId, cancellationToken); 
            
            return items;
        }
    }
}
