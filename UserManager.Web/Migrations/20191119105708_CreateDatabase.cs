using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManager.Web.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CustCode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CustCode", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "rogerwaters19500315", new DateTime(1950, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "rwaters@floydmail.com", "Roger", "Waters" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CustCode", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "davidgilmour19550812", new DateTime(1955, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dgilmour@floydmail.com", "David", "Gilmour" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CustCode", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "nickmason19521101", new DateTime(1952, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nmason@floydmail.com", "Nick", "Mason" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CustCode", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 4, "richardwright19570810", new DateTime(1957, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "rwright@floydmail.com", "Richard", "Wright" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CustCode", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[] { 5, "sydbarrett19540222", new DateTime(1954, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "sbarrett@floydmail.com", "Syd", "Barrett" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
