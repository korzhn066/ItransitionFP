﻿// <auto-generated />
using System;
using FinalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProject.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("JiraAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eca78e87-a7ba-4c81-b0c1-0dd98ec7a291",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJRVH1UwHLDN2Bpk0QWHRwsTVg6WnC/knsEbpjdI105GEfdXTG8YdhKVtoUNUR187g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9a8ea5d5-6869-4a7e-bb18-3677d0a43292",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f7dac184-2ae1-42b0-beda-ff9b91f24ded",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEMzsV9pVU9mXVLp9wDY4rG53YYYE7zLAqtCfWxGlZfiK87oNduXK+j8wAqgeiq2B2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dcd9c4d1-eba2-4dbd-ba7f-1bdfe2eab41d",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                            Description = "Books in this collection",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                            Description = "Films in this collection",
                            Name = "Films"
                        });
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollectionId = 1,
                            Name = ""
                        },
                        new
                        {
                            Id = 2,
                            CollectionId = 1,
                            Name = "The Chronicles of Narnia"
                        },
                        new
                        {
                            Id = 3,
                            CollectionId = 1,
                            Name = "Harry Potter and the philosopher's stone"
                        },
                        new
                        {
                            Id = 4,
                            CollectionId = 2,
                            Name = ""
                        },
                        new
                        {
                            Id = 5,
                            CollectionId = 2,
                            Name = "Film1"
                        },
                        new
                        {
                            Id = 6,
                            CollectionId = 2,
                            Name = "Film1"
                        },
                        new
                        {
                            Id = 7,
                            CollectionId = 2,
                            Name = "Film1"
                        });
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Description",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Author",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "IsRare",
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Published",
                            Type = 3
                        });
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.TagItem", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Index"), 1L, 1);

                    b.HasKey("TagId", "ItemId");

                    b.HasIndex("Index")
                        .IsUnique();

                    b.HasIndex("ItemId");

                    b.ToTable("TagItems");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            ItemId = 1,
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 1,
                            Index = 0
                        },
                        new
                        {
                            TagId = 3,
                            ItemId = 1,
                            Index = 0
                        },
                        new
                        {
                            TagId = 4,
                            ItemId = 1,
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 2,
                            Body = "The Chronicles of Narnia is a series of seven fantasy stories written by Clive Staples Lewis. They tell about the adventures of children in a magical land called Narnia, where animals can talk, magic surprises no one, and good fights evil. The Chronicles of Narnia contains many allusions to Christian ideas in a way that is accessible to young readers. In addition to Christian themes, Lewis describes characters drawn from Greek and Roman mythology and traditional British and Irish fairy tales, including clear similarities to the latter.",
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 2,
                            Body = "Clive Staples Lewis",
                            Index = 0
                        },
                        new
                        {
                            TagId = 3,
                            ItemId = 2,
                            Body = "false",
                            Index = 0
                        },
                        new
                        {
                            TagId = 4,
                            ItemId = 2,
                            Body = "2000-10-2",
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 3,
                            Body = "\"Harry Potter\" is a series of novels written by British writer J. K. Rowling. The books chronicle the adventures of the young wizard Harry Potter, as well as his friends Ron Weasley and Hermione Granger, studying at Hogwarts School of Witchcraft and Wizardry. The main plot is dedicated to the confrontation between Harry and a dark wizard named Lord Voldemort, whose goals include gaining immortality and enslaving the magical world.",
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 3,
                            Body = "Joan Kathleen Rowling",
                            Index = 0
                        },
                        new
                        {
                            TagId = 3,
                            ItemId = 3,
                            Body = "true",
                            Index = 0
                        },
                        new
                        {
                            TagId = 4,
                            ItemId = 3,
                            Body = "1998-1-11",
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 4,
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 4,
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 5,
                            Body = "s",
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 5,
                            Body = "s",
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 6,
                            Body = "s",
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 6,
                            Body = "s",
                            Index = 0
                        },
                        new
                        {
                            TagId = 1,
                            ItemId = 7,
                            Body = "s",
                            Index = 0
                        },
                        new
                        {
                            TagId = 2,
                            ItemId = 7,
                            Body = "s",
                            Index = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            ConcurrencyStamp = "855ebc6c-926f-4624-a4aa-8f1a7ed8ad86",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = "9e445865-a24d-4543-a6c6-9443d048cdb9",
                            ConcurrencyStamp = "b46212ed-1566-42e7-9c6c-d2a77ebed355",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            UserId = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "9e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            UserId = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Collection", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Collections")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Comment", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Item", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.TagItem", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.Item", "Item")
                        .WithMany("TagItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Domain.Entities.Tag", "Tag")
                        .WithMany("TagItems")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinalProject.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Collections");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Collection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Item", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TagItems");
                });

            modelBuilder.Entity("FinalProject.Domain.Entities.Tag", b =>
                {
                    b.Navigation("TagItems");
                });
#pragma warning restore 612, 618
        }
    }
}
