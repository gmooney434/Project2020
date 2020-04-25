using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2020.Migrations
{
    public partial class SeedGuestStay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Date_Of_Birth", "Forename", "PhotoPath", "Surname" },
                values: new object[] { 1, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "files", "Doe" });

            migrationBuilder.InsertData(
                table: "Stays",
                columns: new[] { "Id", "EndDate", "StartDate", "StayId" },
                values: new object[] { 1, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
