using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Data.Seeds
{
    internal static class CollectionSeeder
    {
        internal static void SeedCollections(this ModelBuilder builder)
        {
            var collections = new List<Collection>() {
               new Collection
               {
                   Id = 1,
                   Name = "Books",
                   Description = "Books in this collection",
                   ApplicationUserId = "1e445865-a24d-4543-a6c6-9443d048cdb9"
               },
               new Collection
               {
                   Id = 2,
                   Name = "Films",
                   Description = "Films in this collection",
                   ApplicationUserId = "2e445865-a24d-4543-a6c6-9443d048cdb9"
               }
            };

            builder.Entity<Collection>().HasData(collections);
        }
    }
}
