using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jidelnicek.web.Migrations
{
    /// <inheritdoc />
    public partial class Menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Menu",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menu",
                newName: "Grams");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Menu",
                newName: "Dish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Menu",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Grams",
                table: "Menu",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Dish",
                table: "Menu",
                newName: "Email");
        }
    }
}
