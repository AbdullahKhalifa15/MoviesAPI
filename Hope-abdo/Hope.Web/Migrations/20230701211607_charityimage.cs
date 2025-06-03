using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Web.Migrations
{
    public partial class charityimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Charities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Charities");
        }
    }
}
