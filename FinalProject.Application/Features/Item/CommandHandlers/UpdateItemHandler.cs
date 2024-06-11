using FinalProject.Application.Features.Item.Command;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.CommandHandlers
{
    internal class UpdateItemHandler : IRequestHandler<UpdateItem>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Handle(UpdateItem request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemWithTagsByIdAsync(request.Item.Id, cancellationToken);

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            item.Name = request.Item.Name;

            foreach(var tagItem in request.Item.TagItems)
            {
                var res = item.TagItems
                    .First(ti => ti.TagId == tagItem.TagId && ti.ItemId == tagItem.ItemId)
                    .Body = tagItem.Body;
            }

            await _itemRepository.SaveChangesAsync();
        }
    }
}
