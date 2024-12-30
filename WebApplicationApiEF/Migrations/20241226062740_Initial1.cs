using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationApiEF.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "petAnimals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "petAnimals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
