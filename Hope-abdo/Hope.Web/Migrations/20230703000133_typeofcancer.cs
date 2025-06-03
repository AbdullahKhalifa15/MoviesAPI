using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Web.Migrations
{
    public partial class typeofcancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfCancer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfCancer",
                table: "AspNetUsers");
        }
    }
}
