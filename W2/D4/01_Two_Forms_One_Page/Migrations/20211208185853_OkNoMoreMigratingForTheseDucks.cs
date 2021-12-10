using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_Two_Forms_One_Page.Migrations
{
    public partial class OkNoMoreMigratingForTheseDucks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTimesMigrated",
                table: "Ducks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTimesMigrated",
                table: "Ducks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
