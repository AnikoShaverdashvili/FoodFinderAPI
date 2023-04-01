using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFinderAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "fd",
                table: "UserAllergy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                schema: "fd",
                table: "UserAllergy");
        }
    }
}
