using FinalProject.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? JiraAccountId {get;set;}
        public UserStatus Status { get; set; }
        public ICollection<Collection> Collections { get; set; } 
    }
}
