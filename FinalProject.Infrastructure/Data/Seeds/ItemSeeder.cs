using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Data.Seeds
{
    internal static class ItemSeeder
    {
        internal static void SeedItems(this ModelBuilder builder)
        {
            var items = new List<Item>() {
               new Item
               {
                   Id = 1,
                   CollectionId = 1,
                   Name = ""
               },
               new Item
               {
                   Id = 2,
                   CollectionId = 1,
                   Name = "The Chronicles of Narnia"
               },
               new Item
               {
                   Id = 3,
                   CollectionId = 1,
                   Name = "Harry Potter and the philosopher's stone"
               },

               new Item
               {
                   Id = 4,
                   CollectionId = 2,
                   Name = ""
               },
               new Item
               {
                   Id = 5,
                   CollectionId = 2,
                   Name = "Film1"
               },
               new Item
               {
                   Id = 6,
                   CollectionId = 2,
                   Name = "Film1"
               },
               new Item
               {
                   Id = 7,
                   CollectionId = 2,
                   Name = "Film1"
               },

            };

            builder.Entity<Item>().HasData(items);
        }
    }
}
