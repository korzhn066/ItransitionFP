using FinalProject.Domain.Entities;
using FinalProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Data.Seeds
{
    internal static class TagSeeder
    {
        internal static void SeedTags(this ModelBuilder builder)
        {
            var tags = new List<Tag>() {
                new Tag
                {
                    Id = 1,
                    Type = TagType.LongText,
                    Name = "Description",
                },
                new Tag
                {
                    Id = 2,
                    Type = TagType.Text,
                    Name = "Author",
                },
                new Tag
                {
                    Id = 3,
                    Type = TagType.CheckBox,
                    Name = "IsRare",
                },
                new Tag
                {
                    Id = 4,
                    Type = TagType.Date,
                    Name = "Published",
                }
            };

            builder.Entity<Tag>().HasData(tags);
        }
    }
}
