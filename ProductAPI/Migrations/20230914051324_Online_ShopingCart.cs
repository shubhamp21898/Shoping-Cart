using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.API.Migrations
{
    /// <inheritdoc />
    public partial class Online_ShopingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Oneplus Mobile", "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", 35000.00m, "Nord 2T" },
                    { 2, 1, "Apple Mobile", "https://technextgroup.com/wp-content/uploads/2022/03/Tech-Next-Store-iPhone-13-Pro-Starlight1-1.jpg", 50000.00m, "IPhone 13" },
                    { 3, 1, "Oneplus Mobile", "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", 35000.00m, "Nord 2T" },
                    { 4, 1, "Oneplus Mobile", "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", 35000.00m, "Nord 2" },
                    { 5, 1, "Oneplus Mobile", "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", 45000.00m, "11R" },
                    { 6, 1, "Oneplus Mobile", "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", 35000.00m, "Nord 2T" },
                    { 7, 2, "Dell Laptop", "https://e0.pxfuel.com/wallpapers/939/934/desktop-wallpaper-dell-xps-15-xps9550-4444slv-15-6-inch-traditional-laptop-dell-xps-ultra.jpg", 70000.00m, "XPS 15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
