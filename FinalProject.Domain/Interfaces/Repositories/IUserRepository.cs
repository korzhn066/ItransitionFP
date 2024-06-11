using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories.Base;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
