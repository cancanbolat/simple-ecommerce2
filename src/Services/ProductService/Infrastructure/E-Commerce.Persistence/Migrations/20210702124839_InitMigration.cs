using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Persistence.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CategoryId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.Id, x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => new { x.Id, x.ProductId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_ProductPrices_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Slug", "Title" },
                values: new object[,]
                {
                    { 556925214, "samsung", "Samsung" },
                    { 656925224, "xiaomi", "Xiaomi" },
                    { 756925234, "apple", "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 256925214, "32 GB" },
                    { 256925224, "64 GB" },
                    { 256925234, "128 GB" },
                    { 256925244, "256 GB" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartItemId", "CreatedDate", "Description", "Image", "IsDeleted", "Number", "Slug", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 256925260, null, new DateTime(2021, 7, 2, 15, 48, 38, 651, DateTimeKind.Local).AddTicks(5557), "Smartphone Pro-Grade Camera 8K Video 12MP High Res, Phantom Black", "https://images-na.ssl-images-amazon.com/images/I/61cjeSE%2BZ-L._AC_SL1000_.jpg", false, "132697037186527720", "samsung-galaxy-s21", "SAMSUNG Galaxy S21+", new DateTime(2021, 7, 2, 15, 48, 38, 652, DateTimeKind.Local).AddTicks(5803) },
                    { 256925261, null, new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(648), "Factory Unlocked Android Cell Phone | US Version| Fingerprint ID and Facial Recognition | Long-Lasting...", "https://images-na.ssl-images-amazon.com/images/I/61eCdKZk17L._AC_SL1500_.jpg", false, "132697037186530660", "samsung-galaxy-s10", "Samsung Galaxy S10", new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(657) },
                    { 256925262, null, new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(688), "RAM Kapasitesi 4 GB | RAM Ön Kamera 12 MP", "https://productimages.hepsiburada.net/s/76/550/110000018213462.jpg", false, "132697037186530692", "iphone-12", "IPhone 12", new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(690) },
                    { 256925263, null, new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(820), "RAM Kapasitesi 3 GB RAM | Ön Kamera7,0 MP", "https://productimages.hepsiburada.net/s/66/550/110000007422599.jpg", false, "132697037186530824", "iphone-se", "IPhone SE", new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(822) },
                    { 256925264, null, new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(830), "Ekran Boyutu: 6.81 inç İşletim Sistemi: Android 11 Ram: 8 GB Batarya Kapasitesi: 4600 mAH", "https://productimages.hepsiburada.net/s/75/550/110000017452930.jpg", false, "132697037186530833", "xiaomi-mi-11", "Xiaomi Mi 11", new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(831) },
                    { 256925265, null, new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(837), "128GB 4GB RAM | GSM LTE Factory Unlocked Smartphone | International Model (Onyx Gray)", "https://images-na.ssl-images-amazon.com/images/I/51hIPZc5OjL._AC_SL1000_.jpg", false, "132697037186530840", "xiaomi-redmi-note-10", "Xiaomi Redmi Note 10", new DateTime(2021, 7, 2, 15, 48, 38, 653, DateTimeKind.Local).AddTicks(839) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "Id", "ProductId" },
                values: new object[,]
                {
                    { 556925214, 156925211, 256925260 },
                    { 756925234, 156925216, 256925265 },
                    { 756925234, 156925215, 256925264 },
                    { 656925224, 156925213, 256925262 },
                    { 656925224, 156925214, 256925263 },
                    { 556925214, 156925212, 256925261 }
                });

            migrationBuilder.InsertData(
                table: "ProductPrices",
                columns: new[] { "EditionId", "Id", "ProductId", "CartItemId", "Price" },
                values: new object[,]
                {
                    { 256925214, 156925213, 256925261, null, 1060.45m },
                    { 256925214, 156925229, 256925265, null, 4240.45m },
                    { 256925214, 156925211, 256925260, null, 770.45m },
                    { 256925244, 156925228, 256925264, null, 6240.45m },
                    { 256925234, 156925227, 256925264, null, 5240.45m },
                    { 256925224, 156925226, 256925264, null, 4240.45m },
                    { 256925214, 156925225, 256925264, null, 3240.45m },
                    { 256925224, 156925212, 256925260, null, 1770.45m },
                    { 256925244, 156925224, 256925263, null, 6240.45m },
                    { 256925234, 156925223, 256925263, null, 5240.45m },
                    { 256925224, 156925222, 256925263, null, 4240.45m },
                    { 256925224, 156925230, 256925265, null, 5240.45m },
                    { 256925234, 156925220, 256925262, null, 2950.45m },
                    { 256925224, 156925219, 256925262, null, 2750.45m },
                    { 256925214, 156925218, 256925262, null, 1750.45m },
                    { 256925234, 156925213, 256925260, null, 2770.45m },
                    { 256925244, 156925217, 256925261, null, 4060.45m },
                    { 256925234, 156925216, 256925261, null, 3060.45m },
                    { 256925224, 156925214, 256925261, null, 2060.45m },
                    { 256925214, 156925221, 256925263, null, 3240.45m },
                    { 256925234, 156925231, 256925265, null, 7240.45m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_CartItemId",
                table: "ProductPrices",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_EditionId",
                table: "ProductPrices",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartItemId",
                table: "Products",
                column: "CartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CartItems");
        }
    }
}
