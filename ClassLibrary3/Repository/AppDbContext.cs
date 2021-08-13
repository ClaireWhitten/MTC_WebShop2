using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Sjabloon_AccountAndAdmin_netCore.Domain._TDSdomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        //public DbSet<ProductSupplier> ProductSuppliers { get; set; }


        public DbSet<ProductImage> ProductImages { get; set; }

        //----------------------------------------------testing
        public DbSet<TestModel> TestModel { get; set; }

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

            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "c6aaef1a-8312-4185-8b51-1e3a09421ff7", Name = "Admin", NormalizedName = "ADMIN" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "6ee9e763-1f51-4d0d-a463-b7a8a791234b", Name = "Moderator", NormalizedName = "MODERATOR" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });


            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { IsRemovable = false, Id = "7e19e371-55db-4c16-b9c0-4103de5b39fd", Name = "Basic", NormalizedName = "BASIC" });




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
            // Keys aanpassen
            //---------------------------------------------------------------------------------------------------------------


            //modelBuilder.Entity<ProductSupplier>().HasKey(x => new {x.ProductEAN,x.SupplierID });
       

            //===============================================================================================================
            // relaties aanpassen
            //---------------------------------------------------------------------------------------------------------------



            // Categorie-CategorieParent
            modelBuilder.Entity<ProductCategorie>()
                .HasOne<ProductCategorie>(pc => pc.ParentCategorie)
                .WithMany(pc => pc.SubCategories)
                .HasForeignKey(pc => pc.ParentCategorieID);
                //.OnDelete(DeleteBehavior.Restrict);

            //Product-ProductCategorie
            modelBuilder.Entity<Product>()
                .HasOne<ProductCategorie>(pc => pc.Categorie)
                .WithMany(p => p.Products)
                .HasForeignKey(pc => pc.CategorieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Productreview-Product
            modelBuilder.Entity<ProductReview>()
                .HasOne<Product>(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductEAN)
                .OnDelete(DeleteBehavior.NoAction);

            //ProductReview-Client
            modelBuilder.Entity<ProductReview>()
                .HasOne<Client>(pr => pr.Client)
                .WithMany(u => u.ProductReviews)
                .HasForeignKey(pr => pr.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            //// Tranporter-User
            //modelBuilder.Entity<Transporter>()
            //    .HasOne<User>(t => t.User)
            //    .WithOne(u => u.Transporter)
            //    .HasForeignKey<User>(t => t.UserId);


            // Tranporter-Zone
            modelBuilder.Entity<Zone>()
                .HasOne<Transporter>(z => z.Transporter)
                .WithMany(t => t.Zones)
                .HasForeignKey(z => z.TransporterID)
                .OnDelete(DeleteBehavior.NoAction);

            //Adress-User
            modelBuilder.Entity<Address>()
                .HasOne<ApplicationUser>(a => a.ApplicationUser)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            ////Client-User
            //modelBuilder.Entity<Client>()
            //    .HasOne<User>(c => c.User)
            //    .WithOne(u => u.Client)
            //    .HasForeignKey<User>(c => c.UserId);


            //OrderlineOUT-OrderOUT
            modelBuilder.Entity<OrderLineOUT>()
                .HasOne<OrderOUT>(ol => ol.OrderOUT)
                .WithMany(o => o.OrderLineOUTs)
                .HasForeignKey(ol => ol.OrderOUTId)
                .OnDelete(DeleteBehavior.NoAction)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderlineOUT-Product
            modelBuilder.Entity<OrderLineOUT>()
                .HasOne<Product>(ol => ol.Product)
                .WithMany(p => p.OrderLineOUTs)
                .HasForeignKey(ol => ol.ProductEAN)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderlineOUT-Transporter
            modelBuilder.Entity<OrderLineOUT>()
                .HasOne<Transporter>(ol => ol.Transporter)
                .WithMany(t => t.orderLineOUTs)
                .HasForeignKey(ol => ol.TransporterId)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderOUT-Client
            modelBuilder.Entity<OrderOUT>()
                .HasOne<Client>(oo => oo.Client)
                .WithMany(c => c.OrderOUTs)
                .HasForeignKey(oo => oo.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderOUT-Bonus
            modelBuilder.Entity<Bonus>()
                .HasOne<OrderOUT>(b => b.OrderOUT)
                .WithMany(oo => oo.Bonusses)
                .HasForeignKey(b => b.OrderOUTId)
                .OnDelete(DeleteBehavior.NoAction);

            ////Supplier-User
            //modelBuilder.Entity<Supplier>()
            //    .HasOne<User>(s => s.User)
            //    .WithOne(u => u.Supplier)
            //    .HasForeignKey<User>(s => s.UserID);



            //==============================================bridge table
            //ProductSupplier-Supplier
            //modelBuilder.Entity<ProductSupplier>()
            //    .HasOne(ps => ps.Supplier)
            //    .WithMany(s => s.SupplierProducts)
            //    .HasForeignKey(ps => ps.SupplierID)
            //    .OnDelete(DeleteBehavior.NoAction);


            ////ProductSupplier-Product
            //modelBuilder.Entity<ProductSupplier>()
            //    .HasOne(ps => ps.Product)
            //    .WithMany(p => p.ProductSuppliers)
            //    .HasForeignKey(ps => ps.ProductEAN)
            //    .OnDelete(DeleteBehavior.NoAction);
            //=============================================================



            //modelBuilder.Entity<PersonClub>()
            //    .HasOne(pc => pc.Person)
            //    .WithMany(p => p.PersonClubs)
            //    .HasForeignKey(pc => pc.PersonId);

            //modelBuilder.Entity<PersonClub>()
            //    .HasOne(pc => pc.Club)
            //    .WithMany(c => c.PersonClubs)
            //    .HasForeignKey(pc => pc.ClubId);


            //OrderIN-Supplier
            modelBuilder.Entity<OrderIN>()
                .HasOne<Supplier>(oi => oi.Supplier)
                .WithMany(s => s.OrdersINs)
                .HasForeignKey(oi => oi.SupplierID)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderLineIN-OrderIN
            modelBuilder.Entity<OrderLineIN>()
                .HasOne<OrderIN>(ol => ol.OrderIN)
                .WithMany(oi => oi.OrderLinesINs)
                .HasForeignKey(ol => ol.OrderINID)
                .OnDelete(DeleteBehavior.NoAction);

            //OrderLineIN-Product
            modelBuilder.Entity<OrderLineIN>()
                .HasOne<Product>(ol => ol.Product)
                .WithMany(p => p.OrderLineINs)
                .HasForeignKey(ol => ol.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            //bonus-client
            modelBuilder.Entity<Bonus>()
                .HasOne<Client>(b => b.Client)
                .WithMany(c => c.Bonuses)
                .HasForeignKey(b => b.ClientID)
                .OnDelete(DeleteBehavior.NoAction);


            //product-returnedProduct
            modelBuilder.Entity<ReturnedProduct>()
                .HasOne<Product>(rp => rp.Product)
                .WithMany(p => p.ReturnedProducts)
                .HasForeignKey(rp => rp.EAN)
                .OnDelete(DeleteBehavior.NoAction);

            //Transporter-Zone
            modelBuilder.Entity<Zone>()
                .HasOne<Transporter>(z => z.Transporter)
                .WithMany(t => t.Zones)
                .HasForeignKey(z => z.TransporterID)
                .OnDelete(DeleteBehavior.NoAction);

            //Product-ProductImages
            modelBuilder.Entity<ProductImage>()
                .HasOne(PI => PI.Product)
                .WithMany(P => P.Images)
                .HasForeignKey(PI => PI.ProductEAN)
                .OnDelete(DeleteBehavior.NoAction);



            //===============================================================================================================
            // Delete gedrag aanpassen 
            //---------------------------------------------------------------------------------------------------------------

            //{
            //    table.PrimaryKey("PK_Bonusses", x => x.Code);
            //    table.ForeignKey(
            //        name: "FK_Bonusses_AspNetUsers_ClientID",
            //        column: x => x.ClientID,
            //        principalTable: "AspNetUsers",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Cascade);
            //    table.ForeignKey(
            //        name: "FK_Bonusses_OrderOUTs_OrderOUTId",
            //        column: x => x.OrderOUTId,
            //        principalTable: "OrderOUTs",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Cascade); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //});

            //modelBuilder.Entity<OrderOUT>().


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

            //foreach (var forkkey in modelBuilder.Model.GetEntityTypes().SelectMany(e=> e.GetForeignKeys()))
            //{
            //    forkkey.DeleteBehavior = DeleteBehavior.SetNull;
            //    //forkkey.o
            //}


            //===============================================================================================================
            // unieke sleutels maken
            //---------------------------------------------------------------------------------------------------------------

            modelBuilder.Entity<ProductCategorie>(entity =>
            {
                entity.HasIndex(e => new { e.ParentCategorieID, e.Name }).IsUnique();
            });




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
