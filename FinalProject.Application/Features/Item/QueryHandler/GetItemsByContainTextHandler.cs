using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetItemsByContainTextHandler : IRequestHandler<GetItemsByContainText, List<Domain.Entities.Item>>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemsByContainTextHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Domain.Entities.Item>> Handle(GetItemsByContainText request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.ContainAsync(request.Text, request.Count, cancellationToken);

            return items;
        }
    }
}
