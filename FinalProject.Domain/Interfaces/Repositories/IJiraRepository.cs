using FinalProject.Domain.Models;

namespace FinalProject.Domain.Interfaces.Repositories
{
    public interface IJiraRepository
    {
        Task<string?> CreateUserAsync(string email);
        Task AddUserToRoleAsync(string userId);
        Task CreateIssueAsync(string summary, string collection, string url, string priority, string email, string userId);
        Task<IssuesResponse> GetIssuesAsync(string accountId);
    }
}
