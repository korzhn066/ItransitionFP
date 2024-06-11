namespace FinalProject.ViewModels
{
    public class IndexViewModel
    {
        public List<Domain.Entities.Item> Items { get; set; } = new();
        public List<Domain.Entities.Collection> Collections { get; set; } = new();
        public List<Domain.Entities.Tag> Tags { get; set; } = new();
    }
}
