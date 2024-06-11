using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DBContext context) : base(context)
        {
        }

        public async Task<List<Comment>> GetAllAsync(int itemId)
        {
            var item = await Context.Items
                .Include(i => i.Comments)
                .FirstOrDefaultAsync(i => i.Id == itemId);

            if (item is null)
                throw new ArgumentException(nameof(item));

            return item.Comments
                .OrderByDescending(c => c.Id)
                .ToList();
                
        }
    }
}
