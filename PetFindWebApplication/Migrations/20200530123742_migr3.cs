using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFindWebApplication.Migrations
{
    public partial class migr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalPhoto",
                table: "Advertisement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AnimalPhoto",
                table: "Advertisement",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
