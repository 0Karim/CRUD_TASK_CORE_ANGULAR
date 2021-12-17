using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressInfo_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressInfo_Governate_GovId",
                        column: x => x.GovId,
                        principalTable: "Governate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AddressInfo_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alex" },
                    { 3, "Assuit" }
                });

            migrationBuilder.InsertData(
                table: "Governate",
                columns: new[] { "Id", "GovName" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 2, "Saudi" },
                    { 3, "France" }
                });

            migrationBuilder.InsertData(
                table: "AddressInfo",
                columns: new[] { "Id", "BuildingNumber", "CityId", "GovId", "Street" },
                values: new object[,]
                {
                    { 1, "19", 1, 1, "9" },
                    { 4, "9", 1, 1, "9" },
                    { 2, "19", 2, 2, "9" },
                    { 3, "12", 3, 3, "9" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "FirstName", "IsDeleted", "LastName", "MiddleName", "MobileNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Karim", false, "Sayed", "Alaa", "0101123405940" },
                    { 2, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Karim", false, "Sayed", "Alaa", "0101123405940" },
                    { 3, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Nour", false, "Sayed", "Alaa", "0101123405940" },
                    { 4, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Sondos", false, "Sayed", "Alaa", "0101123405940" },
                    { 5, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Wael", false, "Sayed", "Alaa", "0101123405940" },
                    { 6, 1, new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "karimalaa@test.com", "Ehab", false, "Sayed", "Alaa", "0101123405940" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressInfo_CityId",
                table: "AddressInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressInfo_GovId",
                table: "AddressInfo",
                column: "GovId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AddressInfo");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Governate");
        }
    }
}
