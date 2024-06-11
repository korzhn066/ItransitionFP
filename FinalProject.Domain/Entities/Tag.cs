
using FinalProject.Domain.Enums;

namespace FinalProject.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TagType Type { get; set; }

        public ICollection<TagItem> TagItems { get; set; }
    }
}
