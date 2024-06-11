using FinalProject.Application.Features.Item.Command;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.CommandHandlers
{
    internal class DeleteItemHandler : IRequestHandler<DeleteItem>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Handle(DeleteItem request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetFirstAsync(i => i.Id == request.Id, cancellationToken);

            if (item is null) 
                throw new ArgumentNullException(nameof(item));

            _itemRepository.Delete(item);

            await _itemRepository.SaveChangesAsync();
        }
    }
}
