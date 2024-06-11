using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.Data.Configuration;
using FinalProject.Infrastructure.Data.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinalProject.Infrastructure.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<TagItem> TagItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {

            var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreater != null)
            {
                // Create Database 
                if (!dbCreater.CanConnect())
                {
                    dbCreater.Create();
                }

                // Create Tables
                if (!dbCreater.HasTables())
                {
                    dbCreater.CreateTables();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureCollectionTagItem();

            builder.SeedApplicationUsers();
            builder.SeedIdentityRoles();
            builder.SeedIdentityUserRoles();
            
            builder.SeedCollections();
            builder.SeedItems();
            builder.SeedTags();
            builder.SeedTagItems();

            base.OnModelCreating(builder);
        }
    }
}
