using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetItemsByCollectionIdHandler : IRequestHandler<GetItemsByCollectionId, List<Domain.Entities.Item>>
    {
        private readonly IItemRepository _itemRepository; 
        public GetItemsByCollectionIdHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Domain.Entities.Item>> Handle(GetItemsByCollectionId request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetItemsByCollectionIdAsync(
                request.CollectionId,
                request.Count,
                request.Page,
                cancellationToken);

            return items;
        }
    }
}
