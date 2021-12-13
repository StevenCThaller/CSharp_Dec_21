using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_Many_To_Many.Migrations
{
    public partial class OoopsPartTwoElectricBoogaloo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer");

            migrationBuilder.RenameTable(
                name: "Trainer",
                newName: "Trainers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainers_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Trainers_TrainerId",
                table: "Pokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Trainer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
