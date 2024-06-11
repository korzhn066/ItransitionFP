using FinalProject.Domain.Interfaces.Repositories.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        Task<List<Tag>> GetTheMostPopular(int count, CancellationToken cancellationToken = default);
        Task<List<Tag>> LikeText(int count, string text, CancellationToken cancellationToken = default);    
    }
}
