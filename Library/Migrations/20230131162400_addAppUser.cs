using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "ID", "CreatedDate", "ModifiedDate", "Password", "Status", "UserName", "role" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 31, 19, 24, 0, 527, DateTimeKind.Local).AddTicks(7721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$LAKfPxjJm1.RkvI1/j5KGuZSkBjjN5arLx5nNICR0l3CtOSCTgHUu", 0, "admin", 1 },
                    { 2, new DateTime(2023, 1, 31, 19, 24, 0, 527, DateTimeKind.Local).AddTicks(7742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$Ef8crHrrLIJSQ2wz0YKRcuX2M1IKo.kVXVxayKdNzGElso5SMpepu", 0, "osman", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
