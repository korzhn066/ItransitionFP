using FinalProject.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Domain.Interfaces.Services
{
    public interface IApplicationAuthenticateService
    {
        Task LogOutAsync();
        Task<bool> LoginAsync(LoginModel model);
        Task<IdentityResult> RegisterAsync(RegisterModel model);
    }
}
