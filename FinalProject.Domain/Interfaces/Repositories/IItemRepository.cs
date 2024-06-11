using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories.Base;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Task<List<Item>> GetItemsByCollectionIdAsync(int collectionId, int count, int page, CancellationToken cancellationToken = default);

        Task<Item> GetItemWithTagsByIdAsync(int Id, CancellationToken cancellationToken = default);

        Task<List<Item>> ContainAsync(string text, int count, CancellationToken cancellationToken = default);
        Task<string> GetOwnerById(int id, CancellationToken cancellationToken = default);
        Task<List<Item>> GetLastAsync(int count, CancellationToken cancellationToken = default);
        Task<List<Item?>> GetAllByTagId(int id, CancellationToken cancellationToken = default);
        Task<string> GetCollectionNameByItemId(int id, CancellationToken cancellationToken = default);
    }
}
