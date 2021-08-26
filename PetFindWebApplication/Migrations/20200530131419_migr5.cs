using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFindWebApplication.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalPhotoName",
                table: "Advertisement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalPhotoName",
                table: "Advertisement");
        }
    }
}
