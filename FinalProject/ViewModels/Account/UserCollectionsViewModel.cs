using FinalProject.Domain.Models;

namespace FinalProject.ViewModels.Account
{
    public class UserCollectionsViewModel
    {
        public int CurrentPage { get; set; }
        public int MaxCount { get; set; }
        public string Owner { get; set; } = null!;
        public List<Domain.Entities.Collection> Collections { get; set; } = null!;
        public IssuesResponse Issues { get; set; } = new();
    }
}
