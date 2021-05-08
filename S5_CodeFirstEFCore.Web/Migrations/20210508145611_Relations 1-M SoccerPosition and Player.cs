using Microsoft.EntityFrameworkCore.Migrations;

namespace S5_CodeFirstEFCore.Web.Migrations
{
    public partial class Relations1MSoccerPositionandPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoccerPositionId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_SoccerPositionId",
                table: "Player",
                column: "SoccerPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_SoccerPosition_SoccerPositionId",
                table: "Player",
                column: "SoccerPositionId",
                principalTable: "SoccerPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_SoccerPosition_SoccerPositionId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_SoccerPositionId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "SoccerPositionId",
                table: "Player");
        }
    }
}
