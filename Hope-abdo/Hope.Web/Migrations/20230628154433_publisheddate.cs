using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Web.Migrations
{
    public partial class publisheddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Awarenesses",
                newName: "PublishedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Awarenesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Awarenesses");

            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "Awarenesses",
                newName: "Date");
        }
    }
}
