using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierID = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryID = table.Column<string>(type: "TEXT", nullable: true),
                    QuantityPerUnit = table.Column<double>(type: "REAL", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    UnitslnStock = table.Column<double>(type: "REAL", nullable: false),
                    UnnitsOnOrder = table.Column<double>(type: "REAL", nullable: false),
                    ReorderLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Discontinued = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategorieCategoryID = table.Column<string>(type: "TEXT", nullable: false),
                    ProductsProductID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategorieCategoryID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategorieCategoryID",
                        column: x => x.CategorieCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description", "Picture" },
                values: new object[] { "SK1", "Mobile Phone", "The Phone for every one", "image1.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description", "Picture" },
                values: new object[] { "SK2", "Book", "Book for Student", "image2.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Discontinued", "ProductName", "QuantityPerUnit", "ReorderLevel", "SupplierID", "UnitPrice", "UnitslnStock", "UnnitsOnOrder" },
                values: new object[] { "QW1", "SK1", 5.5999999999999996, "Iphone 15", 1.0, 1, "HJ2", 23.440000000000001, 0.13, 3.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Discontinued", "ProductName", "QuantityPerUnit", "ReorderLevel", "SupplierID", "UnitPrice", "UnitslnStock", "UnnitsOnOrder" },
                values: new object[] { "QW2", "SK2", 5.5999999999999996, "JAVA book", 2.0, 1, "HJ3", 20.440000000000001, 0.13, 3.0 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductID",
                table: "CategoryProduct",
                column: "ProductsProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
