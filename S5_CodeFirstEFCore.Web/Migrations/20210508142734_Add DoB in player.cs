using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace S5_CodeFirstEFCore.Web.Migrations
{
    public partial class AddDoBinplayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "Player",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "Player");
        }
    }
}
