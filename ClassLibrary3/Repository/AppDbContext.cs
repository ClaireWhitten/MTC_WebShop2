using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Sjabloon_AccountAndAdmin_netCore.Domain._TDSdomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MTCrepository.test;
using MTCmodel;
//using BookApplicatie.Domain;

namespace MTCrepository.Repository
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bonus> Bonusses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderIN> OrderINs { get; set; }
        public DbSet<OrderLineIN> OrderLineINs { get; set; }
        public DbSet<OrderLineOUT> OrderLineOUTs { get; set; }
        public DbSet<OrderOUT> OrderOUTs { get; set; }
        public DbSet<ProductCategorie> ProductCategories { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ReturnedProduct> ReturnedProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Zone> Zones { get; set; }



        //===================================================================================================================

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Console.WriteLine("============== onmodelcreating =====================");


            //===============================================================================================================
            // standaard roles seeden
            //---------------------------------------------------------------------------------------------------------------

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { IsRemovable = false, Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { IsRemovable = false, Id = "c6aaef1a-8312-4185-8b51-1e3a09421ff7", Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { IsRemovable = false, Id = "6ee9e763-1f51-4d0d-a463-b7a8a791234b", Name = "Moderator", NormalizedName = "MODERATOR" });
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });




            //===============================================================================================================
            // SuperAdmin toevoegen
            //---------------------------------------------------------------------------------------------------------------

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "super@user.com",
                    NormalizedUserName = "SUPER@USER.COM",
                    Email = "super@user.com",
                    NormalizedEmail = "SUPER@USER.COM",
                    IsRemovable = false,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Test_123")
                }
            );


            //===============================================================================================================
            // bridge tabel nog koppelen (alle Roles voor Superadmin)
            //---------------------------------------------------------------------------------------------------------------

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "7e19e371-55db-4c16-b9c0-4103de5b39fd",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);




            //===============================================================================================================
            // relaties aanpassen
            //---------------------------------------------------------------------------------------------------------------

            //modelBuilder.Entity<Author>()
            //     .HasMany(c => c.Books)
            //     .WithOne(e => e.Author)
            //     .IsRequired();

            //modelBuilder.Entity<BookGenre>()
            //    .HasMany(c => c.Books)
            //    .WithOne(e => e.BookGenre)
            //    .IsRequired();

            //modelBuilder.Entity<Publicher>()
            //    .HasMany(c => c.Books)
            //    .WithOne(e => e.Publicher)
            //    .IsRequired();

            //modelBuilder.Entity<Language>()
            //    .HasMany(c => c.Books)
            //    .WithOne(e => e.Language)
            //    .IsRequired();





            //===============================================================================================================
            // Delete gedrag aanpassen 
            //---------------------------------------------------------------------------------------------------------------

            // standaard worden verwijzigen gedelete in sql on cascading
            // met deze setten we de standaardgedrag voor het verwijderen van child-rows op 
            // NO ACTION ON DELETE, met de bedoeling om geen Rules te mogen verwijderen als er gebruikers aan 
            // gekoppeld is, (child-rows zitten in de bridge tabel)
            // DEZE ZEKER ACHTER base.OnModelCreating(modelBuilder); Plaatsen omdat de geinjecteerde modellen 
            // anders nog niet geladen zijn
            //foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    if (foreignKey.GetDefaultName() == "FK_AspNetUserRoles_AspNetRoles_RoleId")
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;

            //    if (foreignKey.GetDefaultName() == "FK_Books_Authors_AuthorId")
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            //    if (foreignKey.GetDefaultName() == "FK_Books_Genres_BookGenreId")
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            //    if (foreignKey.GetDefaultName() == "FK_Books_Languages_LanguageId")
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            //    if (foreignKey.GetDefaultName() == "FK_Books_Publichers_PublicherId")
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            //}


            //===============================================================================================================
            // unieke sleutels maken
            //---------------------------------------------------------------------------------------------------------------

            //modelBuilder.Entity<Book>(entity => {
            //    entity.HasIndex(e => e.ISBN).IsUnique();
            //});



            //===============================================================================================================
            // seed data toevoegen
            //---------------------------------------------------------------------------------------------------------------


            //modelBuilder.Entity<Product>().HasData(
            //    new Product { EAN = "123", Description = "onderbroek" },
            //    new Product { EAN = "234", Description = "tutter" },
            //    new Product { EAN = "345", Description = "speelbal" },
            //    new Product { EAN = "456", Description = "vogelkooi" }
            //    );

        }
    }
}
