using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_Entity_Intro.Migrations
{
    public partial class AddedMigrationFieldGodThatsConfusing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTimesMigrated",
                table: "Ducks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTimesMigrated",
                table: "Ducks");
        }
    }
}
