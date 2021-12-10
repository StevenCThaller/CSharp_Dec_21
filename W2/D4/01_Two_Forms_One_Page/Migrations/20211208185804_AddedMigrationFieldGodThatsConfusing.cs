using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_Two_Forms_One_Page.Migrations
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
