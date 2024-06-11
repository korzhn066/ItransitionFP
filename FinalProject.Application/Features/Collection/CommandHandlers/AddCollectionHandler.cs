using FinalProject.Application.Features.Collection.Commands;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Application.Features.Collection.CommandHandlers
{
    internal class AddCollectionHandler : IRequestHandler<AddCollection>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ITagItemRepository _tagItemRepository;
        private readonly ITagRepository _tagRepository;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public AddCollectionHandler(
            ICollectionRepository collectionRepository, 
            IItemRepository itemRepository, 
            ITagItemRepository tagItemRepository,
            ITagRepository tagRepository,
            UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _collectionRepository = collectionRepository;
            _itemRepository = itemRepository;
            _tagItemRepository = tagItemRepository;
            _tagRepository = tagRepository;
            _userManager = userManager;
        }

        public async Task Handle(AddCollection request, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByNameAsync(request.Username);

            if (applicationUser is null)
                throw new ArgumentNullException(nameof(applicationUser));

            var collection = new Domain.Entities.Collection
            {
                Name = request.Name,
                Description = request.Description,
                ApplicationUser = applicationUser
            };

            var item = new Domain.Entities.Item
            {
                Name = string.Empty,
                Collection = collection
            };

            await _collectionRepository.AddAsync(collection, cancellationToken);
            await _itemRepository.AddAsync(item, cancellationToken);

            if (request.Tags is not null)
            {
                foreach (var tag in request.Tags)
                {
                    var newTag = await _tagRepository.GetFirstAsync(
                        t => t.Name == tag.Name && t.Type == tag.Type, cancellationToken);

                    if (newTag is null)
                    {
                        newTag = new Domain.Entities.Tag
                        {
                            Name = tag.Name,
                            Type = tag.Type,
                        };

                        await _tagRepository.AddAsync(newTag);
                    }

                    var tagItem = new Domain.Entities.TagItem
                    {
                        Body = null,
                        Tag = newTag,
                        Item = item
                    };

                    await _tagItemRepository.AddAsync(tagItem, cancellationToken);
                }
            }

            await _collectionRepository.SaveChangesAsync();
        }
    }
}
