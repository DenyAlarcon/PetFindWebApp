using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFindWebApplication.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    TelNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementName = table.Column<string>(nullable: false),
                    DateFoundLost = table.Column<DateTime>(nullable: false),
                    AnimalBreed = table.Column<string>(nullable: true),
                    AnimalName = table.Column<string>(nullable: true),
                    AnimalColor = table.Column<string>(nullable: true),
                    AnimalSex = table.Column<string>(nullable: true),
                    PlaceFoundLost = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PersonToCall = table.Column<string>(nullable: false),
                    PersonTelNumber = table.Column<string>(nullable: false),
                    PersonEmail = table.Column<string>(nullable: true),
                    AnimalTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AdvertisementTypeId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisement_AdvertisementType_AdvertisementTypeId",
                        column: x => x.AdvertisementTypeId,
                        principalTable: "AdvertisementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_AnimalType_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementTypeId",
                table: "Advertisement",
                column: "AdvertisementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AnimalTypeId",
                table: "Advertisement",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_CityId",
                table: "Advertisement",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "AdvertisementType");

            migrationBuilder.DropTable(
                name: "AnimalType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
