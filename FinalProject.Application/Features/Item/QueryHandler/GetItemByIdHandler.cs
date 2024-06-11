using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetItemByIdHandler : IRequestHandler<GetItemById, Domain.Entities.Item>
    {
        private readonly IItemRepository _itemRepository;
        public GetItemByIdHandler(IItemRepository itemRepository) 
        { 
            _itemRepository = itemRepository;
        }

        public Task<Domain.Entities.Item> Handle(GetItemById request, CancellationToken cancellationToken)
        {
            var item = _itemRepository.GetItemWithTagsByIdAsync(request.Id, cancellationToken);

            return item;
        }
    }
}
