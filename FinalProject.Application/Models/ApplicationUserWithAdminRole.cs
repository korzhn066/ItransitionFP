namespace FinalProject.Application.Models
{
    public class ApplicationUserWithAdminRole
    {
        public Domain.Entities.ApplicationUser ApplicationUser { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
