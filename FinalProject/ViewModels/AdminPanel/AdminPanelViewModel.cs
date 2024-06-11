using FinalProject.Application.Models;

namespace FinalProject.ViewModels.AdminPanel
{
    public class AdminPanelViewModel
    {
        public List<ApplicationUserWithAdminRole> ApplicationUserWithAdminRoles { get; set; } = new();
    }
}
