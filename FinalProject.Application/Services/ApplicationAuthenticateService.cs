using FinalProject.Domain.Entities;
using FinalProject.Domain.Enums;
using FinalProject.Domain.Interfaces.Services;
using FinalProject.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Application.Services
{
    public class ApplicationAuthenticateService : IApplicationAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationAuthenticateService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user is null)
                return false;

            if (user.Status == UserStatus.Block)
                return false;

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (result)
                await _signInManager.SignInAsync(user, false);

            return result;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Status = UserStatus.Unblock
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return result;
        }
    }
}
