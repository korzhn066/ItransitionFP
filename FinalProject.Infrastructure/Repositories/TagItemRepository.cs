using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;

namespace FinalProject.Infrastructure.Repositories
{
    public class TagItemRepository : RepositoryBase<TagItem>, ITagItemRepository
    {
        public TagItemRepository(DBContext context) : base(context)
        {
        }
    }
}
