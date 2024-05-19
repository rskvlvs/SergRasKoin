using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SergRasKoin.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Addedcourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Isnnode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    course = table.Column<long>(type: "bigint", nullable: false),
                    dateTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Isnnode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
