using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahlatci.Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "PRODUCTIMAGES",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "PRODUCTIMAGES",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "ORDERS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "ORDERS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "ORDERDETAILS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "ORDERDETAILS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "CUSTOMERS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "CUSTOMERS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "COMMENTS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "COMMENTS",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "CATERGORIES",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "CATERGORIES",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "PRODUCTIMAGES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "PRODUCTIMAGES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "ORDERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "ORDERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "ORDERDETAILS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "ORDERDETAILS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "CUSTOMERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "CUSTOMERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "COMMENTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "COMMENTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_BY",
                table: "CATERGORIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "CATERGORIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }
    }
}
