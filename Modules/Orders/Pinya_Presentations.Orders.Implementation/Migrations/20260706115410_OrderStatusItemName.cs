using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinya_Presentations.Orders.Implementation.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusItemName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Orders",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "Orders",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "Orders",
                table: "OrderItems");
        }
    }
}
