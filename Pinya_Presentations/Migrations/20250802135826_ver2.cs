using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinya_Presentations.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Employees",
                newName: "Name_Lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Employees",
                newName: "Name_Firstname");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "EmployeeFamilyMembers",
                newName: "Name_Lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "EmployeeFamilyMembers",
                newName: "Name_Firstname");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Candidates",
                newName: "Name_Lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Candidates",
                newName: "Name_Firstname");

            migrationBuilder.AddColumn<string>(
                name: "Name_Degrees",
                table: "Employees",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_DegreesBehind",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Middlename",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Degrees",
                table: "EmployeeFamilyMembers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_DegreesBehind",
                table: "EmployeeFamilyMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Middlename",
                table: "EmployeeFamilyMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Degrees",
                table: "Candidates",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_DegreesBehind",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Middlename",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Degrees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name_DegreesBehind",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name_Middlename",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name_Degrees",
                table: "EmployeeFamilyMembers");

            migrationBuilder.DropColumn(
                name: "Name_DegreesBehind",
                table: "EmployeeFamilyMembers");

            migrationBuilder.DropColumn(
                name: "Name_Middlename",
                table: "EmployeeFamilyMembers");

            migrationBuilder.DropColumn(
                name: "Name_Degrees",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Name_DegreesBehind",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Name_Middlename",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Name_Lastname",
                table: "Employees",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name_Firstname",
                table: "Employees",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "Name_Lastname",
                table: "EmployeeFamilyMembers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name_Firstname",
                table: "EmployeeFamilyMembers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "Name_Lastname",
                table: "Candidates",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name_Firstname",
                table: "Candidates",
                newName: "Firstname");
        }
    }
}
