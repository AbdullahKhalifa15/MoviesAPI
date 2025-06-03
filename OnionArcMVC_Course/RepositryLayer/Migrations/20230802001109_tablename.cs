using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositryLayer.Migrations
{
    public partial class tablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_StudentId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentId",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment");

            migrationBuilder.RenameTable(
                name: "StudentAssignment",
                newName: "StudentAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignments",
                newName: "IX_StudentAssignments_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "StudentId", "AssignmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_AspNetUsers_StudentId",
                table: "StudentAssignments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentId",
                table: "StudentAssignments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_AspNetUsers_StudentId",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentId",
                table: "StudentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.RenameTable(
                name: "StudentAssignments",
                newName: "StudentAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignments_AssignmentId",
                table: "StudentAssignment",
                newName: "IX_StudentAssignment_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment",
                columns: new[] { "StudentId", "AssignmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_StudentId",
                table: "StudentAssignment",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
