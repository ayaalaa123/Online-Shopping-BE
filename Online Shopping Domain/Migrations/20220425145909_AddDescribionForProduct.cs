using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Shopping_Domain.Migrations
{
    public partial class AddDescribionForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Describtion",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Describtion",
                table: "Products");
        }
    }
}
