using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Web.Migrations
{
    public partial class someinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Awarenesses",
                newName: "Someinfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Someinfo",
                table: "Awarenesses",
                newName: "Link");
        }
    }
}
