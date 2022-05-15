using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Shopping_Domain.Migrations
{
    public partial class RenameDescriptionCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Describtion",
                table: "Products",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Describtion");
        }
    }
}
