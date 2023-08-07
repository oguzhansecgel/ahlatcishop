using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahlatci.Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIdChanged3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CATERGORIES_CatergoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatergoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatergoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CATERGORIES_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "CATERGORIES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CATERGORIES_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CatergoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatergoryId",
                table: "Products",
                column: "CatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CATERGORIES_CatergoryId",
                table: "Products",
                column: "CatergoryId",
                principalTable: "CATERGORIES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
