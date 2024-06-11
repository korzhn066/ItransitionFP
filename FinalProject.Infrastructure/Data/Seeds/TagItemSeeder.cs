using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data.Seeds
{
    internal static class TagItemSeeder
    {
        internal static void SeedTagItems(this ModelBuilder builder)
        {
            var collectionTagItems = new List<TagItem>
            {
                new TagItem
                {
                    TagId = 1,
                    ItemId = 1,
                    Body = null
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 1,
                    Body = null
                },
                new TagItem
                {
                    TagId = 3,
                    ItemId = 1,
                    Body = null
                },
                new TagItem
                {
                    TagId = 4,
                    ItemId = 1,
                    Body = null
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 2,
                    Body = "The Chronicles of Narnia is a series of seven fantasy stories written by Clive Staples Lewis. They tell about the adventures of children in a magical land called Narnia, where animals can talk, magic surprises no one, and good fights evil. The Chronicles of Narnia contains many allusions to Christian ideas in a way that is accessible to young readers. In addition to Christian themes, Lewis describes characters drawn from Greek and Roman mythology and traditional British and Irish fairy tales, including clear similarities to the latter."
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 2,
                    Body = "Clive Staples Lewis"
                },
                new TagItem
                {
                    TagId = 3,
                    ItemId = 2,
                    Body = "false"
                },
                new TagItem
                {
                    TagId = 4,
                    ItemId = 2,
                    Body = "2000-10-2"
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 3,
                    Body = "\"Harry Potter\" is a series of novels written by British writer J. K. Rowling. The books chronicle the adventures of the young wizard Harry Potter, as well as his friends Ron Weasley and Hermione Granger, studying at Hogwarts School of Witchcraft and Wizardry. The main plot is dedicated to the confrontation between Harry and a dark wizard named Lord Voldemort, whose goals include gaining immortality and enslaving the magical world."
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 3,
                    Body = "Joan Kathleen Rowling"
                },
                new TagItem
                {
                    TagId = 3,
                    ItemId = 3,
                    Body = "true"
                },
                new TagItem
                {
                    TagId = 4,
                    ItemId = 3,
                    Body = "1998-1-11"
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 4,
                    Body = null
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 4,
                    Body = null
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 5,
                    Body = "s"
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 5,
                    Body = "s"
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 6,
                    Body = "s"
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 6,
                    Body = "s"
                },

                new TagItem
                {
                    TagId = 1,
                    ItemId = 7,
                    Body = "s"
                },
                new TagItem
                {
                    TagId = 2,
                    ItemId = 7,
                    Body = "s"
                },
            };

            builder.Entity<TagItem>().HasData(collectionTagItems);
        }
    }
}
