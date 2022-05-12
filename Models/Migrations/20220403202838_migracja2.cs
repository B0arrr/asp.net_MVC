using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class migracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RodzajPokoju",
                table: "Pokoje");

            migrationBuilder.AddColumn<int>(
                name: "RodzajPokojuId",
                table: "Pokoje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RodzajePokojow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RodzajPokoju = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajePokojow", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokoje_RodzajPokojuId",
                table: "Pokoje",
                column: "RodzajPokojuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokoje_RodzajePokojow_RodzajPokojuId",
                table: "Pokoje",
                column: "RodzajPokojuId",
                principalTable: "RodzajePokojow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokoje_RodzajePokojow_RodzajPokojuId",
                table: "Pokoje");

            migrationBuilder.DropTable(
                name: "RodzajePokojow");

            migrationBuilder.DropIndex(
                name: "IX_Pokoje_RodzajPokojuId",
                table: "Pokoje");

            migrationBuilder.DropColumn(
                name: "RodzajPokojuId",
                table: "Pokoje");

            migrationBuilder.AddColumn<int>(
                name: "RodzajPokoju",
                table: "Pokoje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
