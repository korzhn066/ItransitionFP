using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<List<Comment>> GetAllAsync(int itemId);
    }
}
