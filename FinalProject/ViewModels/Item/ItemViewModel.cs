using FinalProject.Domain.Entities;

namespace FinalProject.ViewModels.Item
{
    public class ItemViewModel
    {
        public int CollectionId { get; set; }
        public string Owner { get; set; } = null!;
        public Domain.Entities.Item Item { get; set; } = null!;
        public List<Domain.Entities.Comment> Comments { get; set; } 
    }
}
