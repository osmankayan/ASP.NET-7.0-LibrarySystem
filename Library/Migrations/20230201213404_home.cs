using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class home : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9064), "$2a$11$l.O.0lVJwsIw21hrLHr.q.7cN.ECjKoKwsqEbOA/aYXM2l3V4S73y" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9080), "$2a$11$IWG0MGASPELElga.uk3d/uuT8MM/N6nEZFGZqkr.D4JM8g86nYRTe" });

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 2, 0, 34, 4, 404, DateTimeKind.Local).AddTicks(9422));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 19, 35, 15, 866, DateTimeKind.Local).AddTicks(9720));
        }
    }
}
