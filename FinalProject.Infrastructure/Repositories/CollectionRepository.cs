using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class CollectionRepository : RepositoryBase<Collection>, ICollectionRepository
    {
        public CollectionRepository(DBContext context) : base(context)
        {
        }

        public async Task<List<Collection>> GetByUsernameAsync(string username, int count, int page, CancellationToken cancellationToken = default)
        {
            var user = await Context.Users
                .Include(u => u.Collections)
                .FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return user.Collections
                .Skip(page * count)
                .Take(count)
                .ToList();
        }

        public async Task<Collection?> GetWithItemsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var collection = await Context.Collections
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return collection;
        }

        public async Task<List<Collection>> GetTheBiggestAsync(int count, CancellationToken cancellationToken = default)
        {
            var collections = await Context.Collections
                .OrderByDescending(c => c.Items.Count)
                .Take(count)
                .ToListAsync(cancellationToken);

            return collections;
        }

        public async Task<List<Tag>> GetTagsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var collection = await Context.Collections
                .Include(c => c.Items)
                .ThenInclude(i => i.TagItems)
                .ThenInclude(ti => ti.Tag)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            var item = collection.Items
                .FirstOrDefault();

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            var result = new List<Tag>();

            foreach(var tagItem in item.TagItems)
            {
                result.Add(tagItem.Tag);
            }

            return result;
        }

        public async Task<string> GetOwnerByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var collection = await Context.Collections
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            return collection.ApplicationUser.UserName;
        }

        public async Task<List<Collection>> ContainAsync(string text, int count, CancellationToken cancellationToken = default)
        {
            var collections = await Context.Collections
                .Where(c => EF.Functions.Contains(c.Name, text))
                .Take(count)
                .ToListAsync(cancellationToken);

            return collections;
        }
    }
}
