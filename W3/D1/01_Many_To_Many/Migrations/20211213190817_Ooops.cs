using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_Many_To_Many.Migrations
{
    public partial class Ooops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHaveMoves_Move_MoveId",
                table: "PokemonHaveMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Move",
                table: "Move");

            migrationBuilder.RenameTable(
                name: "Move",
                newName: "Moves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHaveMoves_Moves_MoveId",
                table: "PokemonHaveMoves",
                column: "MoveId",
                principalTable: "Moves",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHaveMoves_Moves_MoveId",
                table: "PokemonHaveMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.RenameTable(
                name: "Moves",
                newName: "Move");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Move",
                table: "Move",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHaveMoves_Move_MoveId",
                table: "PokemonHaveMoves",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
