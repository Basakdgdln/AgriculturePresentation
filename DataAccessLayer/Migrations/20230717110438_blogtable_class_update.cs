using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class blogtable_class_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Blogs",
                newName: "ImageClass");

            migrationBuilder.AddColumn<string>(
                name: "ContentClass",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentClass",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "ImageClass",
                table: "Blogs",
                newName: "Class");
        }
    }
}
