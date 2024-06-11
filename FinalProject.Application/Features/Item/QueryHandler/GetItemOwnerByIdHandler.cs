using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Item.QueryHandler
{
    internal class GetItemOwnerByIdHandler : IRequestHandler<GetItemOwnerById, string>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemOwnerByIdHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<string> Handle(GetItemOwnerById request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetOwnerById(request.Id, cancellationToken);
        }
    }
}
