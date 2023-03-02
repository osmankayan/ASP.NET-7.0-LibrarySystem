using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "StudentDetail");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "StudentDetail");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9196), "$2a$11$HGSHfUN5KoN2FNL8RrxSbOfb/LK7u4JTcCvYhdZuewZVAhh963IIe" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9217), "$2a$11$GdjGL855Y29zszzd8z6vBuCECnfPnTYS8eUmUFrz9bv0pEAZIP/MO" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "CreatedDate", "FirstName", "LastName", "ModifiedDate", "Status", "gender" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9714), "kemal", "akca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 2, new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9717), "sabiha", "abadan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 3, new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9720), "oguz", "karadag", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "Birthday", "CreatedDate", "ModifiedDate", "SchoolNumber", "Status", "StudentID" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9751), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "345", 0, 1 },
                    { 2, new DateTime(1999, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9760), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "456", 0, 2 },
                    { 3, new DateTime(2001, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9763), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "745", 0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "StudentDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "StudentDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 31, 19, 24, 0, 527, DateTimeKind.Local).AddTicks(7721), "$2a$11$LAKfPxjJm1.RkvI1/j5KGuZSkBjjN5arLx5nNICR0l3CtOSCTgHUu" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 31, 19, 24, 0, 527, DateTimeKind.Local).AddTicks(7742), "$2a$11$Ef8crHrrLIJSQ2wz0YKRcuX2M1IKo.kVXVxayKdNzGElso5SMpepu" });
        }
    }
}
