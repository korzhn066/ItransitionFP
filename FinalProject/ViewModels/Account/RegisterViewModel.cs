using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;
    }
}
