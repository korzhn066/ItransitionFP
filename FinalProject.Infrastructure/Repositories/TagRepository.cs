using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(DBContext context) : base(context)
        {
        }

        public async Task<List<Tag>> GetTheMostPopular(int count, CancellationToken cancellationToken = default)
        {
            var tags = await Context.Tags
                .OrderByDescending(t => t.TagItems.Count)
                .Take(count)
                .ToListAsync(cancellationToken);

            return tags;
        }

        public async Task<List<Tag>> LikeText(int count, string text, CancellationToken cancellationToken = default)
        {
            var tags = await Context.Tags
                .Where(t => EF.Functions.Like(t.Name, text + "%"))
                .ToListAsync(cancellationToken);

            return tags;
        }
    }
}
