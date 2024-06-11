using FinalProject.Domain.Entities;

namespace FinalProject.ViewModels.Collection
{
    public class AddCollectionViewModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Tag> Tags { get; set; } = null!;
    }
}
