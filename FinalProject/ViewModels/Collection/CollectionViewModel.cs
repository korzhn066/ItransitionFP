using FinalProject.Domain.Entities;

namespace FinalProject.ViewModels.Collection
{
    public class CollectionViewModel
    {
        public Domain.Entities.Collection Collection { get; set; } = null!;
        public List<Domain.Entities.Item> Items { get; set; } = null!;
        public string Owner { get; set; } = null!;
    }
}
