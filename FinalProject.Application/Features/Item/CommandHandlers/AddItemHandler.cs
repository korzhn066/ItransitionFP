using FinalProject.Application.Features.Item.Command;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Item.CommandHandlers
{
    internal class AddItemHandler : IRequestHandler<AddItem>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITagItemRepository _tagItemRepository;

        public AddItemHandler(
            IItemRepository itemRepository, 
            ITagItemRepository tagItemRepository)
        {
            _itemRepository = itemRepository;
            _tagItemRepository = tagItemRepository;
        }

        public async Task Handle(AddItem request, CancellationToken cancellationToken)
        {
            var item = new Domain.Entities.Item
            {
                Name = request.Name,
                CollectionId = request.CollectionId,
            };

            await _itemRepository.AddAsync(item, cancellationToken);

            foreach (var tagBody in request.TagsBodyWithId)
            {
                var tagItem = new TagItem
                {
                    Item = item,
                    TagId = tagBody.TagId,
                    Body = tagBody.Body
                };

                await _tagItemRepository.AddAsync(tagItem, cancellationToken);
            }

            await _itemRepository.SaveChangesAsync();
        }
    }
}
