using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinya_Presentations.Migrations
{
    /// <inheritdoc />
    public partial class milestones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveDateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => new { x.EmployeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Milestones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("INSERT INTO [Milestones] " +
                "([EmployeeId], [EffectiveDateTime], [Company], [Location]) " +
                "SELECT [Id], GETDATE(), [Company], [Location] FROM [Employees]");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Employees");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("UPDATE emp " +
                "SET [Company]=mil.[Company], [Location]=mil.Location " +
                "FROM [Milestones] mil " +
                "RIGHT JOIN [Employees] emp ON mil.[EmployeeId]=emp.[Id]");

            migrationBuilder.DropTable(
                name: "Milestones");
        }
    }
}
