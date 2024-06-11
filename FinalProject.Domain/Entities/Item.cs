namespace FinalProject.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int CollectionId { get; set; }
        public Collection Collection { get; set; } = null!;
        public ICollection<TagItem> TagItems { get; set; }  
        public ICollection<Comment> Comments { get; set; }
    }
}
