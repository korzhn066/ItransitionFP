using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context) { }

        public Task<List<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = Context.Users
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}
