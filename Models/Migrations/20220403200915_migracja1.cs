using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class migracja1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RodzajPokoju",
                table: "Pokoje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RodzajPokoju",
                table: "Pokoje");
        }
    }
}
