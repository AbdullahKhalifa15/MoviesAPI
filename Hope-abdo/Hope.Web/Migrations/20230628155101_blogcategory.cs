using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Web.Migrations
{
    public partial class blogcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Awarenesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Awarenesses");
        }
    }
}
