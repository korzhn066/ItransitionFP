namespace FinalProject.ViewModels.Item
{
    public class UpdateItemViewModel
    {
        public Domain.Entities.Item Item { get; set; } = null!;
        public bool IsValid { get; set; } = true;
    }
}
