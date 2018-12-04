using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrashCourseServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: true),
                    weight = table.Column<int>(nullable: false),
                    bodyFat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
