using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Entities
{
    [Index(nameof(Index), IsUnique = true)]
    public class TagItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;

        public int? ItemId { get; set; }
        public Item? Item { get; set; }

        public string? Body { get; set; }
    }
}
