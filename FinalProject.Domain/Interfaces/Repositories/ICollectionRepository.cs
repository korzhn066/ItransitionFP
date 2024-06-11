using FinalProject.Domain.Interfaces.Repositories.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface ICollectionRepository : IRepositoryBase<Collection>
    {
        public Task<List<Collection>> GetTheBiggestAsync(int count, CancellationToken cancellationToken = default);
        public Task<Collection?> GetWithItemsByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<List<Collection>> GetByUsernameAsync(string username, int count, int page, CancellationToken cancellationToken = default);
        public Task<List<Tag>> GetTagsByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<string> GetOwnerByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Collection>> ContainAsync(string text, int count, CancellationToken cancellationToken = default);
    }
}
