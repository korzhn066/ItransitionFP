namespace FinalProject.Domain.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public ICollection<Item> Items { get; set; }
    }
}
