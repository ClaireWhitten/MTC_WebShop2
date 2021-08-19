using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRemovable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRemovable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentCategorieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentCategorieID",
                        column: x => x.ParentCategorieID,
                        principalTable: "ProductCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    HouseNumberAdditional = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameAdditional = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BTW = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CompanyNummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transporters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporters_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    EAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BTWPercentage = table.Column<double>(type: "float", nullable: false),
                    CountInStock = table.Column<int>(type: "int", nullable: false),
                    MaxStock = table.Column<int>(type: "int", nullable: false),
                    MinStock = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    RatingCount = table.Column<int>(type: "int", nullable: true),
                    RecommendedUnitPrice = table.Column<double>(type: "float", nullable: false),
                    SolderPrice = table.Column<double>(type: "float", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.EAN);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "ProductCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderOUTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    HouseNumberAdditional = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DiscountClientPercentage = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOUTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderOUTs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderINs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderINs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderINs_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TransporterID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Transporters_TransporterID",
                        column: x => x.TransporterID,
                        principalTable: "Transporters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductEAN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductEAN",
                        column: x => x.ProductEAN,
                        principalTable: "Products",
                        principalColumn: "EAN");
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductEAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductEAN",
                        column: x => x.ProductEAN,
                        principalTable: "Products",
                        principalColumn: "EAN");
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductsEAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SuppliersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsEAN, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductsEAN",
                        column: x => x.ProductsEAN,
                        principalTable: "Products",
                        principalColumn: "EAN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<int>(type: "int", maxLength: 1000, nullable: false),
                    Outlet = table.Column<bool>(type: "bit", nullable: false),
                    EAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderLineOUTID = table.Column<int>(type: "int", nullable: false),
                    NewOrderLineOUTID = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnedProducts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnedProducts_Products_EAN",
                        column: x => x.EAN,
                        principalTable: "Products",
                        principalColumn: "EAN");
                });

            migrationBuilder.CreateTable(
                name: "Bonusses",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    OrderOUTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonusses", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Bonusses_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bonusses_OrderOUTs_OrderOUTId",
                        column: x => x.OrderOUTId,
                        principalTable: "OrderOUTs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderLineOUTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransporterId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ProductEAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderOUTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineOUTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLineOUTs_OrderOUTs_OrderOUTId",
                        column: x => x.OrderOUTId,
                        principalTable: "OrderOUTs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLineOUTs_Products_ProductEAN",
                        column: x => x.ProductEAN,
                        principalTable: "Products",
                        principalColumn: "EAN");
                    table.ForeignKey(
                        name: "FK_OrderLineOUTs_Transporters_TransporterId",
                        column: x => x.TransporterId,
                        principalTable: "Transporters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderLineINs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderINID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineINs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLineINs_OrderINs_OrderINID",
                        column: x => x.OrderINID,
                        principalTable: "OrderINs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrderLineINs_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "EAN");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsRemovable", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "79438ccc-b82d-4712-9448-4bed72d0e1ef", false, "SuperAdmin", "SUPERADMIN" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "ce6f90a3-eb6d-4fe6-885a-641e2be3a398", false, "Administrator", "ADMINISTRATOR" },
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "884035dc-23d6-4870-8cff-fb185fe6ef12", false, "Client", "CLIENT" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "fdc3760e-eab3-4825-8dbd-01dc403fdcd1", false, "Transporter", "TRANSPORTER" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "ca01224a-283c-4048-b1f9-e3d6e27cd3e3", false, "Supplier", "SUPPLIER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "IsRemovable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "fb3cd166-6f24-4071-8954-682ef98b2066", "super@user.com", true, true, false, false, null, "SUPER@USER.COM", "SUPER@USER.COM", "AQAAAAEAACcQAAAAEMHMkHnLvavXi/fIfe4ciSXJ8Yj0TKP/HdOYa0Zrj/5OSdkbW91WjPP5N303DiCFpg==", null, false, "d1da164e-8a0d-433d-91d6-f097690fcde1", false, "super@user.com" },
                    { "e08d7ef7-2615-4385-844f-81834bb6e776", 0, "f853e240-d182-454f-9751-4f217b9a8ef1", "client@mtc.com", true, true, false, false, null, "CLIENT@MTC.COM", "CLIENT@MTC.COM", "AQAAAAEAACcQAAAAELhOQ0Jko7SyTnTPRxqC4y8V8KtHUn5Jh8hEg9wXYCZNzdhg+7w3PxpuQWYcj6tkyA==", null, false, "baaa9dcf-26fd-4d62-9bfb-81a5bb4703b4", false, "client@mtc.com" },
                    { "a0392e57-a71c-4314-b87c-ba8dc7628fcc", 0, "9d0c8408-4320-4f6f-9c59-45380c6d2fa7", "transporter@mtc.com", true, true, false, false, null, "TRANSPORTER@MTC.COM", "TRANSPORTER@MTC.COM", "AQAAAAEAACcQAAAAEOb/8QhMBueLQRXy1QG1mEwBPPbUeDX0Rfub2YKmSMOC9w4GpBDO1/YIZdnOpQDmPg==", null, false, "c3cf937c-c6ea-49fc-a7ae-3e25656af579", false, "transporter@mtc.com" },
                    { "f0cd17fb-639c-4bd4-aa51-cb64259d9743", 0, "d9a17586-dd2e-42a9-9fca-c320c1a2a6a4", "supplier@mtc.com", true, true, false, false, null, "SUPPLIER@MTC.COM", "SUPPLIER@MTC.COM", "AQAAAAEAACcQAAAAENhZE4dQ151J5QVShmiFbyokd8EA1ls9nR5IR5K8OObM4nsXm0bNyAvCwJzdPkWYlQ==", null, false, "fb0a0f40-16d1-40ee-94a3-41e3288096b0", false, "supplier@mtc.com" },
                    { "c6bbcf91-ab26-4bf1-a8ac-6251444d1464", 0, "475ee17e-4fd2-4f66-a7fa-972723bafd62", "UserAdmin@mtc.com", true, true, false, false, null, "USERADMIN@MTC.COM", "USERADMIN@MTC.COM", "AQAAAAEAACcQAAAAEIEeZXew7++zlADFQSZEd6z0ed39H9u5u8jwJ0Q8QSuVDlB58XBRxS/kafF92Fowpg==", null, false, "577f2c5f-5d8b-44eb-93c8-b6d7e28a5e1d", false, "UserAdmin@mtc.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "e08d7ef7-2615-4385-844f-81834bb6e776" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "a0392e57-a71c-4314-b87c-ba8dc7628fcc" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "f0cd17fb-639c-4bd4-aa51-cb64259d9743" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "c6bbcf91-ab26-4bf1-a8ac-6251444d1464" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DiscountPercentage", "FirstName", "LastName", "NameAdditional" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0.0, "Super", "User", null },
                    { "e08d7ef7-2615-4385-844f-81834bb6e776", 0.0, "testClientvoornaam", "testclientAchternaam", "tst" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BTW", "CompanyNummer", "Name", "WebSite" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "BE0123456789", "0123456789", "MTCSuperUserSupplier", "www.MTCtestsupplier.be" },
                    { "f0cd17fb-639c-4bd4-aa51-cb64259d9743", "22222222222222", "22222222222", "TestSupplier", "www.MTCtestsupplier.be" }
                });

            migrationBuilder.InsertData(
                table: "Transporters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "MTCSuperUserTransporter" },
                    { "a0392e57-a71c-4314-b87c-ba8dc7628fcc", "TestTransporter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserID",
                table: "Addresses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bonusses_ClientID",
                table: "Bonusses",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Bonusses_OrderOUTId",
                table: "Bonusses",
                column: "OrderOUTId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderINs_SupplierID",
                table: "OrderINs",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineINs_OrderINID",
                table: "OrderLineINs",
                column: "OrderINID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineINs_ProductID",
                table: "OrderLineINs",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineOUTs_OrderOUTId",
                table: "OrderLineOUTs",
                column: "OrderOUTId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineOUTs_ProductEAN",
                table: "OrderLineOUTs",
                column: "ProductEAN");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineOUTs_TransporterId",
                table: "OrderLineOUTs",
                column: "TransporterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOUTs_ClientId",
                table: "OrderOUTs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategorieID_Name",
                table: "ProductCategories",
                columns: new[] { "ParentCategorieID", "Name" },
                unique: true,
                filter: "[ParentCategorieID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductEAN",
                table: "ProductImages",
                column: "ProductEAN");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ClientId",
                table: "ProductReviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductEAN",
                table: "ProductReviews",
                column: "ProductEAN");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategorieId",
                table: "Products",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SuppliersId",
                table: "ProductSupplier",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedProducts_ClientId",
                table: "ReturnedProducts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedProducts_EAN",
                table: "ReturnedProducts",
                column: "EAN");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_TransporterID",
                table: "Zones",
                column: "TransporterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bonusses");

            migrationBuilder.DropTable(
                name: "OrderLineINs");

            migrationBuilder.DropTable(
                name: "OrderLineOUTs");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "ReturnedProducts");

            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderINs");

            migrationBuilder.DropTable(
                name: "OrderOUTs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transporters");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
