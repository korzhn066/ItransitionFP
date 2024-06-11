using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Data.Configuration
{
    internal static class CollectionTagItemConfiguration
    {
        internal static void ConfigureCollectionTagItem(this ModelBuilder builder)
        {
            builder.Entity<TagItem>()
                .HasKey(ti =>  new { ti.TagId, ti.ItemId });
            

            builder.Entity<TagItem>()
               .HasOne(ti => ti.Tag)
               .WithMany(t => t.TagItems)
               .HasForeignKey(ti => ti.TagId);

            builder.Entity<TagItem>()
               .HasOne(ti => ti.Item)
               .WithMany(i => i.TagItems)
               .HasForeignKey(ti => ti.ItemId);
        }
    }
}
