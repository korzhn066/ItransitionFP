using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(DBContext context) : base(context)
        {
        }

        public async Task<List<Item>> ContainAsync(string text, int count, CancellationToken cancellationToken = default)
        {
            var items = await Context.Items
                .Where(i => EF.Functions.Contains(i.Name, text))
                .Take(count)
                .ToListAsync();

            if (items.Count < count) {
                var itemsByBody = await Context.TagItems
                    .Where(ti => ti.Body != null && ti.Item != null && EF.Functions.Contains(ti.Body, text))
                    .Take(count - items.Count)
                    .Select(ti => ti.Item)
                    .ToListAsync(cancellationToken);

                items.AddRange(itemsByBody!);
            }

            return items;
        }

        public async Task<List<Item?>> GetAllByTagId(int id, CancellationToken cancellationToken = default)
        {
            var tag = await Context.Tags
                .Include(t => t.TagItems)
                .ThenInclude(ti => ti.Item)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (tag is null)
                throw new ArgumentNullException(nameof(tag));

            return tag.TagItems
                .Where(ti => ti.Item != null && ti.Body != null)
                .Select(ti => ti.Item).ToList();
              
        }

        public async Task<string> GetCollectionNameByItemId(int id, CancellationToken cancellationToken = default)
        {
            var item = await Context.Items
                .Include(i => i.Collection)
                .FirstAsync(i => i.Id == id);

            return item.Collection.Name;
        }

        public async Task<List<Item>> GetItemsByCollectionIdAsync(int collectionId, int count, int page, CancellationToken cancellationToken = default)
        {
            var collection = await Context.Collections
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == collectionId, cancellationToken);

            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            return collection.Items
                .Skip(count * page + 1)
                .Take(count)
                .ToList();
        }

        public async Task<Item> GetItemWithTagsByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var item = await Context.Items
                .Include(i => i.TagItems)
                .ThenInclude(ti => ti.Tag)
                .FirstOrDefaultAsync(i => i.Id == Id, cancellationToken);

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return item;
        }

        public async Task<List<Item>> GetLastAsync(int count, CancellationToken cancellationToken = default)
        {
            var items = await Context.Items
                .Where(i => i.Name != string.Empty)
                .OrderByDescending(i => i.Id)
                .Take(count)
                .ToListAsync(cancellationToken);

            return items;
        }

        public async Task<string> GetOwnerById(int id, CancellationToken cancellationToken = default)
        {
            var item = await Context.Items
                .Include(i => i.Collection)
                .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return item.Collection.ApplicationUser.UserName;
        }
    }
}
